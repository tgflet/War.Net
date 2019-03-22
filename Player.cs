using System;
using System.Collections.Generic;


namespace decked{
    class Player{
        public string name;
        public List<Card> hand;
        public List<Card> stack;
        public Player(string label){
        name = label;
        hand = new List<Card>();
        stack = new List<Card>();
        }
        public void draw(Deck deck){
            hand.Add(deck.deal());
        }
        public Card discard(){
            if (hand.Count<1){
                System.Console.WriteLine("Game over Bro, You don't have that many cards.");
                return null;
            }
            else{
                Card discarded = hand[0];
                hand.Remove(hand[0]);
                System.Console.WriteLine($"{name} flipped the {discarded.stringVal} of {discarded.suit}.");
                return discarded;
            }
        }
        public void hand_shuffle(){
            Random rand = new Random();
            for (int i = 0; i < hand.Count; i++){
                int r = i + rand.Next(hand.Count-i);
                Card temp = hand[r];
                hand[r]=hand[i];
                hand[i]=temp;
            }
        }
        public Card stealth_discard(){
            if (hand.Count<1){
                System.Console.WriteLine("Game over Bro, You don't have that many cards.");
                return null;
            }
            else{
                Card discarded = hand[0];
                hand.Remove(hand[0]);
                return discarded;
            }
        }
        public List<Card> flip(Player player){
            stack.Add(player.discard());
            return stack;
        }
        public List<Card> stealth_flip(Player player){
            stack.Add(player.stealth_discard());
            return stack;
        }     
    }
}  