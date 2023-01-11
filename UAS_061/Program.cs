using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_061
{
    class Node
    {
        public int ID_brg;
        public string Nama_brg;
        public string Jenis_brg;
        public int Harga_brg;
        public Node next;
    }

    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }

        public void Insert()
        {
            int id_brg;
            int hrg_brg;
            string nm_brg;
            string jns_brg;
            Console.Write("\nMasukkan ID barang: ");
            id_brg = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama barang:");
            nm_brg = Console.ReadLine();
            Console.Write("\nMasukkan Jenis Barang:");
            jns_brg = Console.ReadLine();
            Console.Write("\nMasukkan Harga Barang:");
            hrg_brg = Convert.ToInt32(Console.ReadLine());
            Node nodeBaru = new Node();
            nodeBaru.ID_brg = id_brg;
            nodeBaru.Nama_brg = nm_brg;
            nodeBaru.Jenis_brg = jns_brg;
            nodeBaru.Harga_brg = hrg_brg;

            if (LAST == null || id_brg <= LAST.ID_brg)
            {
                if ((LAST != null) && (id_brg == LAST.ID_brg))
                {
                    Console.WriteLine("\nData sama tidak diijinkan\n");
                    return;
                }
                return;
                nodeBaru.next = LAST;
            }
            
            Node previous, current;
            current = LAST;

            while ((current != null) && (id_brg >= current.ID_brg))
            {
                if (id_brg == current.ID_brg)
                {
                    Console.WriteLine("\nData sama tidak diijinkan\n");
                    return;
                }
                
                previous = current;
                current = current.next;
            }

            nodeBaru.next = LAST.next;
            LAST.next = nodeBaru;
            LAST = nodeBaru;

        }

        public bool Search(string jns_brg, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next;
                current != LAST;
                previous = current,
                current = current.next)
            {
                if (jns_brg == current.Jenis_brg)
                    return (true);

            }
            if (jns_brg == LAST.Jenis_brg)
                return true;
            else
                return (false);
        }

        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList Kosong");
            else
            {
                Console.WriteLine("\nData di dalam list adalah :\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.Jenis_brg + " " + currentNode.ID_brg + " " + currentNode.Nama_brg + " " + currentNode.Harga_brg + "\n");
                    Console.Write(LAST.Jenis_brg + " " + LAST.ID_brg + " " + LAST.Nama_brg + " " + currentNode.Harga_brg + "\n");
                }
            }
        }

        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambahkan data ke dalam list ");
                    Console.WriteLine("2. Menampilkan data yang ada di dalam list");
                    Console.WriteLine("3. Mencari data di dalam list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nMAsukkan pilihanmu (1-4) : ");

                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.Insert();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();

                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkan Jenis Barang yang ingin di cari : ");
                                string jns = Console.ReadLine();
                                if (obj.Search(jns, ref prev, ref curr) == false)
                                    Console.WriteLine("\nPencarian tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nPencarian ditemukan");
                                    Console.WriteLine("\nID Barang: " + curr.ID_brg);
                                    Console.WriteLine("\nNama Barang: " + curr.Nama_brg);
                                }
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}


// jawaban no. 2
//Algoritma yang digunakan berdasakan studi kasus di atas yaitu algoritma Circular Single Linked List
//Saya memilih Algoritma Circular Linked List dikarenakan agar data yang ditampilkan tidak berulang ulang,
//dan ketika data yang dimasukkan berada di akhir list maka pointer akan otomatis beralih ke awal sehingga
//data yang ditampilkan tidak berulang ulang.  Saya juga menggunakan linked list karena data yang di masukkan banyak dan tidak memiliki batasan data.


//jawaban no.3
// Algoritma Queue merupakan struktur data dimana satu data dapat ditambakan diakhir disebut REAR dan data dihapus dari yang paling terkahir disebut FRONT

//jawaban no.4
// a. kedalaman yang dimiliki struktur tersebut : 4
// b. Metode Inorder 