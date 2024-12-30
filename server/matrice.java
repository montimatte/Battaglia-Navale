public class matrice {
    private String[][] matrix;

    public matrice() {
        this.matrix = new String[10][10];
    }

    public void popola(String str)
    {
        //split della stringa con \r \n

        String[] righe = str.split("\n");

        //for per ogni elemento delle righe
        for (int r = 0; r < righe.length; r++) {
            //split con ; e ottengo l'array delle celle
            String[] celle = righe[r].split(";");
            // un altro for per ogni elemento metto dentro la matrice in posizione i j quel valore
            for (int c = 0; c < celle.length; c++) {
                this.matrix[r][c] = celle[c];
            }
        }
            
    }
}
