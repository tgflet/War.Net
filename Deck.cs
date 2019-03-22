using System;
using System.Collections.Generic;

namespace decked{
    class Deck{
        public List<Card> cards;

        public Deck(){
            cards = new List<Card>();
            reset();
            
        }
        public Card deal(){
            Card dealt = cards[0];
            // System.Console.WriteLine($"Dealt the {dealt.stringVal} of {dealt.suit}");
            cards.Remove(cards[0]);
            return (dealt);
        }
        public void shuffle(){
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++){
                int r = i + rand.Next(cards.Count-i);
                Card temp = cards[r];
                cards[r]=cards[i];
                cards[i]=temp;
            }
        }
        public void reset(){
                cards.Clear();
                string[] suit = {"Spades","Hearts","Diamonds","Clubs"};
                string[] sval = {"Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten","Jack","Queen","King","Ace"};
                for (int i = 0; i < suit.Length; i++){
                    for (int j = 0; j<sval.Length; j++){
                       cards.Add(new Card(suit[i],sval[j],j+2)); 
                    }
                }
            }
    }
}