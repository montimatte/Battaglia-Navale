import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

class server{
    public static void main(String[] args) throws IOException {
        ready();
        //fare funzione leggi matrice che arriva dal client
    }

    public static void ready() throws IOException
    {
        DatagramSocket sochet = new DatagramSocket(12345);

        DatagramPacket client1 = new DatagramPacket(null, 0);
        DatagramPacket client2 = new DatagramPacket(null, 0);


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

            // se è 1 mi salvo l'indirizzo e la porto del primo client che ha messo pronto
            if(nPronto == 1)
            { 
                client1.setAddress(packet.getAddress());
                client1.setPort(packet.getPort());
            }
            
            // se arrivo a 2 invio inizio a entrambi i client
            if(nPronto == 2)
            {
                client2.setAddress(packet.getAddress());
                client2.setPort(packet.getPort());

                String messaggioInizio = "inizio";
                byte[] bufferInizio = messaggioInizio.getBytes();

                client1.setData(bufferInizio);
                client1.setLength(bufferInizio.length);

                client2.setData(bufferInizio);
                client2.setLength(bufferInizio.length);

                sochet.send(client1);
                sochet.send(client2);

                break;
            }
        }

        //pacchetto da inviare al primo client per indicare il turno
        String messaggioTurno = "è il tuo turno";
        byte[] bufferTurno = messaggioTurno.getBytes();
        client1.setData(bufferTurno);
        client1.setLength(bufferTurno.length);

        sochet.send(client1);
    }
   

}