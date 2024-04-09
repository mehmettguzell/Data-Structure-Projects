namespace Palindrom_kelime_stack_ve_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackYapisi st = new StackYapisi();
            QueueYapisi que = new QueueYapisi();
            String kelime;
            Console.WriteLine("...Polindrom Kelime Bulma Uygulaması...");
            Console.Write("Kelime giriniz: "); kelime = Console.ReadLine();
            
            for (int i = 0; i < kelime.Length; i++)
            {
                st.push(kelime[i]);
                que.enQueue(kelime[i]);
            }
            bool sonuc = true;

            while ( !que.isEmpty() ) 
            {
                if (que.deQueue() != st.pop())
                {
                    sonuc = false;
                }
            }
            if ( sonuc )
            {
                Console.WriteLine($"==> {kelime} Polindromdur <==");
            }
            else
            {
                Console.WriteLine($"==> {kelime} Polindrom değildir <==");
            }

            Console.ReadKey();
        }
    }
    class Node
    {
        public char data;
        public Node next;
        public Node( char data )
        {
            this.data = data;
            next = null;
        }
    }
    class StackYapisi
    {
        public Node top;
        public StackYapisi()
        {
            top = null;
        }
        public bool isEmpty()
        {
            return top == null;
        }
        public void push( char data )
        {
            Node eleman = new Node( data );
            if ( isEmpty() )
            {
                top = eleman;
            }
            else
            {
                eleman.next = top;
                top = eleman;
            }
        }
        public char pop()
        {
            char ch;
            if (isEmpty())
            {
                ch = 's';
            }
            else
            {
                ch = top.data;
                top = top.next;
            }
            return ch;

        }
    }
    class QueueYapisi
    {
        public Node front;
        public Node rear;
        public QueueYapisi()
        {
            this.front = this.rear = null;
        }
        public bool isEmpty()
        {
            return front == null;
        }
        public void enQueue( char data ) 
        {
            Node eleman = new Node( data ); 
            if (isEmpty())
            {
                front = rear = eleman;
            }
            else
            {
                rear.next = eleman;
                rear = eleman;
            }
        }
        public char deQueue()
        {
            char ch;
            if (isEmpty())
            {
                ch = 'q';
            }
            else
            {
                ch = front.data;
                front = front.next;
            }
            return ch;
        }
    }
}
