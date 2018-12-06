#!/bin/sh

# włączenie forwardowania pakietów:

echo 1 > /proc/sys/net/ipv4/ip_forward
# wyczyśćmy tablice iptables odpowiedzialne za nat i za filtrowanie pakietów:

iptables -F -t nat
iptables -X -t nat
iptables -F -t filter
iptables -X -t filter

# Domyślnie odrzucamy i nie zezwalany na forwardowanie pakietów

#iptables -t filter -P FORWARD DROP

# Zezwalamy na by serwer przepuszczał pakiety które pochodzą z naszej sieci
# lokalnej lub są dla niej przeznaczone.

#iptables -t filter -A FORWARD -s 192.168.0.0/255.255.0.0 -d 0/0 -j ACCEPT

#iptables -t filter -A FORWARD -s 0/0 -d 192.168.0.0/255.255.0.0 -j ACCEPT

iptables -t filter -P FORWARD DROP


iptables -A FORWARD -p udp -j ACCEPT --dport 53
iptables -A FORWARD -p udp -j ACCEPT --sport 53 
iptables -A OUTPUT -p udp -j ACCEPT --dport 53
iptables -A INPUT -p udp -j ACCEPT --sport 53

iptables -A FORWARD -j ACCEPT -p icmp
iptables -A OUTPUT -j ACCEPT -p icmp
iptables -A INPUT -j ACCEPT -p icmp
echo '1'

iptables -A FORWARD -d www.interia.pl -s 192.168.10.0/255.255.255.0 -j DROP
iptables -A FORWARD -s www.interia.pl -d 192.168.10.0/255.255.255.0 -j DROP
echo '2'
iptables -A INPUT -s www.interia.pl -j DROP -p tcp --sport 80
iptables -A OUTPUT -d www.interia.pl -j DROP -p tcp --dport 80
echo '3'
iptables -A FORWARD -d www.wp.pl -s 192.168.10.11 -j DROP -p tcp --dport 80
iptables -A FORWARD -s www.wp.pl -d 192.168.10.11 -j DROP -p tcp --sport 80
echo '4'
iptables -A FORWARD -d www.onet.pl -s 192.168.10.12 -j DROP -p tcp --dport 80
iptables -A FORWARD -s www.onet.pl -d 192.168.10.12 -j DROP -p tcp --sport 80
echo '5'
iptables -A FORWARD -j ACCEPT -p tcp --dport 80
iptables -A FORWARD -j ACCEPT -p tcp --sport 80
echo '6'


# Teraz nakazujemy by wszystkie pakiety pochodzące z lanu były maskowane
iptables -t filter -A FORWARD -s 192.168.10.0/255.255.255.0 -d 0/0 -j ACCEPT
iptables -t filter -A FORWARD -s 0/0 -d 192.168.10.0/255.255.255.0 -j ACCEPT

iptables -t nat -A PREROUTING -d 10.64.103.233 -p tcp --dport 18 -j DNAT --to 192.168.10.11:22
iptables -t nat -A POSTROUTING -s 192.168.10.11 -p tcp --sport 22 -j SNAT --to 10.64.103.233:18
 
iptables -t nat -A PREROUTING -d 10.64.103.216 -j DNAT --to 192.168.10.12
iptables -t nat -A POSTROUTING -s 192.168.10.12 -j SNAT --to 10.64.103.216

iptables -t nat -A POSTROUTING -s 192.168.10.0/24 -d 0/0 -j MASQUERADE
