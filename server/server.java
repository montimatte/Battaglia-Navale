import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

class server{
    static DatagramSocket sochet;
    static DatagramPacket client1;
    static DatagramPacket client2;
    static matrice m1;
    static matrice m2;


    public static void main(String[] args) throws IOException {
        sochet = new DatagramSocket(12345);
        client1 = new DatagramPacket(new byte[0], 0);
        client2 = new DatagramPacket(new byte[0], 0);
        m1 = new matrice();
        m2 = new matrice();
        ready();
        //fare funzione leggi matrice che arriva dal client
        leggi();
    }

    public static void ready() throws IOException
    {
        int nPronto=0;
        while (true) { 

            DatagramPacket packet = new DatagramPacket(new byte[0],0);
            String messaggio = recive(packet);
            
            System.out.println(messaggio);

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
                
                send(messaggioInizio, client1);
                send(messaggioInizio, client2);
                break;
            }
        }
    }

    public static void leggi() throws IOException
    {
        int contatore = 0;
        while(contatore < 2)
        {
            DatagramPacket packet = new DatagramPacket(new byte[0],0);
            String messaggio = recive(packet);
    
            if(packet.getAddress() == client1.getAddress() && packet.getPort() == client1.getPort())
            {
                m1.popola(messaggio);
                contatore++;
            }
            else if(packet.getAddress() == client2.getAddress() && packet.getPort() == client2.getPort())
            {
                m2.popola(messaggio);
                contatore++;
            }
        }
    }

    public static void turno(DatagramPacket giocatore, DatagramPacket avversario,matrice mGiocatore, matrice mAvversario) throws IOException
    {
        String messaggioTurno = "è il tuo turno";
        send(messaggioTurno, giocatore);

        //ricevo il messaggio che è un riga;colonna
        DatagramPacket packet = new DatagramPacket(null,-1);
        String messaggio = recive(packet);

        String[] campi = messaggio.split(";");
        int riga = Integer.parseInt(campi[0]);
        int colonna = Integer.parseInt(campi[1]);

        int colpita = mAvversario.getColpita(riga, colonna);

        //invio la risposta a entrambi
        String risposta = riga+";"+colonna+";"+colpita;
        send(risposta, giocatore);
        send(risposta, avversario);

        //controllo se il gioco è finito
        packet = new DatagramPacket(null,-1);
        messaggio = recive(packet);

        if(messaggio.equals("game over"))
        {
            send("fine gioco", giocatore);
            send("fine gioco", avversario);
        }
        else
        {
            send("continua", giocatore);
            send("continua", avversario);
        }

    }

    public static void gioca() throws IOException
    {
        //pacchetto da inviare al primo client per indicare il turno
        int turno = 1;
        while(true)
        {
            if(turno == 1)
            {
                turno(client1,client2,m1,m2);
                turno++;
            }
            else if(turno == 2)
            {
                turno(client2,client1,m2,m1);
                turno--;
            }
        }
       
    }

    public static String recive(DatagramPacket packet) throws IOException
    {
        byte[] buffer = new byte[1500];
        packet.setData(buffer, 0, buffer.length);
        sochet.receive(packet);
        
        String messaggio = new String(packet.getData(),0,packet.getLength());

        return messaggio;
    }

    public static void send(String messaggio,DatagramPacket packet)throws IOException
    {
        byte[] bufferRisposta = messaggio.getBytes();
        packet.setData(bufferRisposta);
        packet.setLength(bufferRisposta.length);
        sochet.send(packet);
    }
}