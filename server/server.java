import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

class server{
    public static void main(String[] args) throws IOException {
        ready();
    }

    public static void ready() throws IOException
    {
        DatagramSocket sochet = new DatagramSocket(12345);

        while (true) { 
            byte[] buffer = new byte[1500];
            DatagramPacket packet = new DatagramPacket(buffer, buffer.length);
            sochet.receive(packet);
            
            String messaggio = new String(packet.getData(),0,packet.getLength());
            System.out.println(messaggio);

            int nPronto = 0;

            if(messaggio.equals("pronto"))
            {              
                nPronto++;
            }
            
            if(nPronto == 2)
            {
                String messaggioInviare = "inizio";
                byte[] bufferInviare = messaggioInviare.getBytes();
                DatagramPacket packetInviare = new DatagramPacket(bufferInviare, bufferInviare.length);
                packetInviare.setAddress(packet.getAddress());
                packetInviare.setPort(packet.getPort());
                sochet.send(packetInviare);

                return;
            }
        }
    }
   

}