using System;

namespace decked
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to the Millennia War!");
            System.Console.WriteLine("What's your name Cadet?");
            // string recruit=Console.ReadLine();

            // Player enemy = new Player ("Enemy");
            // Player user = new Player (recruit);
            // Deck war_deck = new Deck();
            // war_deck.shuffle();
            // int i = 0;
            // while (i<26){
            // enemy.draw(war_deck);
            // user.draw(war_deck);
            // i++;
            // }

            Player enemy = new Player("Tom");
            Player user = new Player("Kate");
            Deck war_deck = new Deck();
            war_deck.shuffle();
            int i = 0;
            while (i<26){
            enemy.draw(war_deck);
            user.draw(war_deck);
            i++;
            }
            
            int counter = 0;
            int cycle = 0;
            while(enemy.hand.Count<52 ||  user.hand.Count<52){
                if(enemy.hand.Count==0 || user.hand.Count==0){
                    System.Console.WriteLine("That was the Final Battle. The war is over, but did anything really get accomplished?");
                    int duration = (cycle*250 + counter);
                    System.Console.WriteLine($"The conflict lasted {duration} amount of turns");
                    // System.Console.WriteLine(cycle);
                    break;
                }
                else{
                    if (counter > 250){
                        enemy.hand_shuffle();
                        user.hand_shuffle();
                        System.Console.WriteLine("Reshuffling Deck!");
                        cycle++;
                        counter = 0;
                    }
                    else{
                    counter++;
                    enemy.flip(enemy);
                    user.flip(user);
                    compare(enemy, user);
                    }
                }
            }  

        } 
        public static void start(){
            Player enemy = new Player ("Enemy");
            Player user = new Player ("User");
            Deck war_deck = new Deck();
            war_deck.shuffle();
            int i = 0;
            while (i<26){
            enemy.draw(war_deck);
            user.draw(war_deck);
            i++;
            }
        }
        public static void compare(Player one, Player two){
            if(one.stack[one.stack.Count-1].val>two.stack[two.stack.Count-1].val){
                System.Console.WriteLine($"{one.name} wins this battle");
                for (int i = 0; i < one.stack.Count; i++)
                {
                    one.hand.Add(one.stack[i]);
                }
                one.stack.Clear();
                for (int j = 0; j<two.stack.Count; j++){
                    one.hand.Add(two.stack[j]);
                }
                two.stack.Clear();
            }
            else if (two.stack[two.stack.Count-1].val>one.stack[one.stack.Count-1].val){
                System.Console.WriteLine($"{two.name} wins this battle");
                for (int i = 0; i < one.stack.Count; i++)
                {
                    two.hand.Add(one.stack[i]);
                }
                one.stack.Clear();
                for (int j = 0; j<two.stack.Count; j++){
                    two.hand.Add(two.stack[j]);
                }
                two.stack.Clear();
            }
            else{
                War(one,two);
                if(one.stack.Count<1){
                    terminate(two);
                }
                else if(two.stack.Count<1){
                    terminate(one);
                }
                else{
                compare(one,two);
                }
            }

        }
        public static void terminate(Player winner){
            System.Console.WriteLine($"The guns have quieted and {winner.name} has won the war."); 
;
        }
        public static void War(Player one, Player two){
            if(one.hand.Count<4){
                System.Console.WriteLine($"Yo {one.name}, Game over Bro, You don't have enough cards for this battle.");
                one.hand.Clear();
                one.stack.Clear();
                return;
                
            }
            else if(two.hand.Count<4){
                System.Console.WriteLine($"Yo {two.name}, Game over Bro, You don't have have enough cards for this battle.");
                two.hand.Clear();
                two.stack.Clear();
                return;

            }
            else{
            one.stealth_flip(one);
            two.stealth_flip(two);
            System.Console.WriteLine("I");
            one.stealth_flip(one);
            two.stealth_flip(two);
            System.Console.WriteLine("Declare");
            one.stealth_flip(one);
            two.stealth_flip(two);
            System.Console.WriteLine("War!");
            one.flip(one);
            two.flip(two);
            }
        }    
    }
}
