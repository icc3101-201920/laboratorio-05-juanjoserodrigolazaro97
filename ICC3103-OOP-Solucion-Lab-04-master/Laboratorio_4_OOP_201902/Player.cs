using Laboratorio_4_OOP_201902.Cards;
using Laboratorio_4_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_4_OOP_201902
{
    public class Player
    {
        //Constantes
        private const int LIFE_POINTS = 2;
        private const int START_ATTACK_POINTS = 0;

        //Static
        private static int idCounter;

        //Atributos
        private int id;
        private int lifePoints;
        private int attackPoints;
        private Deck deck;
        private Hand hand;
        private Board board;
        private SpecialCard captain;

        //Constructor
        public Player()
        {
            LifePoints = LIFE_POINTS;
            AttackPoints = START_ATTACK_POINTS;
            Deck = new Deck();
            Hand = new Hand();
            Id = idCounter++;
        }

        //Propiedades
        public int Id { get => id; set => id = value; }
        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            set
            {
                this.lifePoints = value;
            }
        }
        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }
        public Deck Deck
        {
            get
            {
                return this.deck;
            }
            set
            {
                this.deck = value;
            }
        }
        public Hand Hand
        {
            get
            {
                return this.hand;
            }
            set
            {
                this.hand = value;
            }
        }
        public Board Board
        {
            get
            {
                return this.board;
            }
            set
            {
                this.board = value;
            }
        }
        public SpecialCard Captain
        {
            get
            {
                return this.captain;
            }
            set
            {
                this.captain = value;
            }
        }

        //Metodos
        public void DrawCard(int cardId = 0)
        {

            
            if (deck.Cards[cardId].GetType().Name == nameof(CombatCard))
            {
                CombatCard carta = (CombatCard) deck.Cards[cardId];
          
                var na = carta.Name;
                var ty = carta.Type;
                var ef = carta.Effect;
                var at = carta.AttackPoints;
                var he = carta.Hero;
                CombatCard carta2 = new CombatCard(na, ty, ef, at, he);
               


                hand.AddCard(carta2);

                deck.DestroyCard(cardId);

            }
            else {
                SpecialCard carta = (SpecialCard)deck.Cards[cardId];

                var na = carta.Name;
                var ty = carta.Type;
                var ef = carta.Effect;
          
         
                SpecialCard carta2 = new SpecialCard(na, ty, ef);



                hand.AddCard(carta2);

                deck.DestroyCard(cardId);
            }

           
            /*
            1- Definir si la carta a robada del mazo es CombatCard o SpecialCard
            2- Luego deberá agregar la carta robada al mazo. En este paso debe respetar el tipo por referencia, para esto:
                2.1- Asigne una variable a la carta robada del mazo, ejemplo, CombatCard card = deck.Cards[cardId]
                2.2- Cree una CombatCard o SpecialCard (dependiendo del caso) con los valores de la carta del mazo.
                2.3- Agregue la nueva carta a la mano
            Elimine la carta del mazo.
            Hint: Utilice los métodos ya creados en Hand y Deck (AddCard y DestroyCard), no se preocupe de la implementacion de estos aun.*/
            throw new NotImplementedException();
        }
        public void PlayCard(int cardId, EnumType buffRow = EnumType.None)
        {


            if(hand.Cards[cardId].GetType().Name == nameof(CombatCard))
            {
                CombatCard carta = (CombatCard)hand.Cards[cardId];

                var na = carta.Name;
                var ty = carta.Type;
                var ef = carta.Effect;
                var at = carta.AttackPoints;
                var he = carta.Hero;
                CombatCard carta2 = new CombatCard(na, ty, ef, at, he);






                if (carta2.Type == EnumType.buff)
                {

                    board.AddCard(carta2, id, buffRow);
                }
                else if (carta2.Type == EnumType.weather)  {

                    board.AddCard(carta2);
                }

                hand.DestroyCard(cardId);

            }
            else
            {
                SpecialCard carta = (SpecialCard)Hand.Cards[cardId];

                var na = carta.Name;
                var ty = carta.Type;
                var ef = carta.Effect;


                SpecialCard carta2 = new SpecialCard(na, ty, ef);


                if (carta2.Type == EnumType.buff)
                {

                    board.AddCard(carta2, id, buffRow);
                }
                else if (carta2.Type == EnumType.weather)
                {

                    board.AddCard(carta2);
                }

                hand.DestroyCard(cardId);
            }



            /*Realice el mismo procedimiento que en DrawCard, solo que ahora es desde Hand a Board.
              En caso de CombatCard siga el mismo procedimiento, recuerde que el método AddCard de Board requiere el id del usuario.
              En caso de SpecialCard:
                1- Realice los pasos 2.1 y 2.2 de DrawCard
                2- Identifique el tipo de la carta, 
                    2.1- Si es buff:
                        -El metodo AddCard de Board requiere el Id del usuario
                        -El metodo requiere la entrada buff{fila a la que se va a jugar}. Ejemplo buffmelee, este dato viene en el parámetro buffRow.
                    2.2- Si es weather:
                        -El metodo AddCard solo requiere la carta.
                3- Elimine la carta de la mano. 
             */
            throw new NotImplementedException();
        }
        public void ChangeCard(int cardId)
        {

            


            

            if (hand.Cards[cardId].GetType().Name == nameof(CombatCard))
            {
                CombatCard card = (CombatCard) hand.Cards[cardId];
                CombatCard card2 = new CombatCard(card.Name, card.Type, card.Effect, card.AttackPoints, card.Hero);
                hand.DestroyCard(cardId);
                Random rand = new Random();
                int alea = rand.Next(Deck.Cards.Count);
                //DrawCard(alea);
                Card cartaAleatoria = Deck.Cards[alea];

            }
            else {

                SpecialCard card = (SpecialCard) hand.Cards[cardId];
                SpecialCard card2 = new SpecialCard(card.Name, card.Type, card.Effect);

                hand.DestroyCard(cardId);
                Random rand = new Random();
                int alea = rand.Next(Deck.Cards.Count);
                //DrawCard(alea);

                if (deck.Cards[alea].GetType().Name == nameof(CombatCard))
                {

                }
                else {

                }
                    

            }


                /* Debe cambiar la carta en la posicion cardId de la mano por una carta aleatoria del mazo.
                    1- Defina si la carta a cambiar de la mano es CombatCard o SpecialCard. Luego (Esto permite cambiar la referencia):
                            1.1- Asigne una variable a la carta a cambiar de la mano, ejemplo, CombatCard card = hand.Cards[cardId]
                            1.2- Cree una CombatCard o SpecialCard (dependiendo del caso) con los valores de la carta de la mano a cambiar.
                    2- Elimine la carta de la mano
                    3- Implemente Random
                    4- Cree una variable que obtenga un numero aleatorio dentro del total de cartas del mazo.
                    5- Obtenga la carta aleatoria del mazo (puede utilizar el método DrawCard) y cree una nueva carta con sus valores. Agreguela a la mano. 
                    6- Elimine la carta aleatoria escogida del mazo.
                    7- Agregue la carta original de la mano al mazo.
                */
                throw new NotImplementedException();
        }

        public void FirstHand()
        {
            /*Debe obtener 10 cartas aleatorias del mazo y asignarlas a la mano.
            Utilice el metodo DrawCard con 10 numeros de id aleatorios.
            */

            var i = 0;

            while (i < 10) {
                Random rand = new Random();
                int alea = rand.Next(Deck.Cards.Count);

                DrawCard(alea);

                i += 1;

            }

            throw new NotImplementedException();
        }

        public void ChooseCaptainCard(SpecialCard captainCard)
        {
            Captain = captainCard;
        }


   

    }
}
