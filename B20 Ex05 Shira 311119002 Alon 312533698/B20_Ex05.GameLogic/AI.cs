using System;

namespace B20_Ex05
{
    internal struct AIMemCell
    {
        internal int m_Value;
        internal int m_Row;
        internal int m_Col;
        internal int m_PairRow;
        internal int m_PairCol;
        internal bool m_PairFound;
        internal bool m_SentFirstLoc;

        internal AIMemCell(int i_Row, int i_Col, int i_Value)
        {
            m_Row = i_Row;
            m_Col = i_Col;
            m_Value = i_Value;
            m_PairFound = false;
            m_SentFirstLoc = false;
            m_PairCol = -1;
            m_PairRow = -1;
        }
    }

    internal class AI
    {
        private const int k_MaxMem = 6;
        private const int k_NotFound = -1;

        private AIMemCell[] m_AIMem = new AIMemCell[k_MaxMem];
        private int m_Turns = 0;
        private int m_Revealed = 0;
        private bool m_DoSmartChoice = false;
        private int m_PairsInMem = 0;
        private int m_IndexToAdd = 0;        

        public void PlayTurn(ref int io_Row, ref int io_Col, Board i_Gameboard)
        {
            //// Gets parameters and active gameboard 
            //// Returns (by ref) row and col for reveal - choose randomize or smart (every 3 turns)
            
            bool doRandom = true;
            m_Revealed++;

            if (m_Revealed % 2 != 0)
            { // Check first or second reveal
                m_Turns++;
            }

            if (m_Turns % 3 == 0)
            { // Play smart every 3 turns.
                m_DoSmartChoice = true;
            }

            if (m_DoSmartChoice && m_PairsInMem > 0) 
            { // Play smart if there is a pair in memory and it's time for smart choice
                int index = memoryInRealTime(i_Gameboard);

                if (index != k_NotFound) 
                {
                    smartChoice(ref io_Row, ref io_Col, index);
                    doRandom = false;
                }
            }

            if (doRandom)
            {
                randomChoice(ref io_Row, ref io_Col, i_Gameboard);
            }
        }

        private void smartChoice(ref int io_Row, ref int io_Col, int i_Index)
        {
            //// Gets Col & Row parameters by ref, and Index known to be location on AI-Memory[Index]=pair
            //// Return the Col and Row of the pairs (First, and Second on Second-call)
            
            if (!m_AIMem[i_Index].m_SentFirstLoc)
            { // Send the first coordinate exposer
                io_Row = m_AIMem[i_Index].m_Row;
                io_Col = m_AIMem[i_Index].m_Col;
                m_AIMem[i_Index].m_SentFirstLoc = true;                
            }
            else
            {
                io_Row = m_AIMem[i_Index].m_PairRow;
                io_Col = m_AIMem[i_Index].m_PairCol;              
            }

            if (m_Revealed % 2 == 0) 
            { // After expose pair, reset setting for what needed
                m_PairsInMem--;
                m_AIMem[i_Index].m_PairFound = false;
                m_AIMem[i_Index].m_SentFirstLoc = false;
                m_DoSmartChoice = false;
            }
        }

        internal void UpdateMemory(int i_Row, int i_Col, int i_Value)
        { 
            //// Update AI Memory with tails that just got revealed on board, Function called when:
            //// 1. Player played full turn (two exposures) and didn't reveal a pair.
            //// 2. Each AI Turn (not if revealed pair in full turn)

            bool isFound = false;

            if (m_PairsInMem != k_MaxMem) 
            { // If memeory is not full of pairs 
                for (int i = 0; i < m_AIMem.Length; i++) 
                { // Find if the AI has seen this tile-pair before
                    if (m_AIMem[i].m_Value == i_Value)
                    { // Found this value before
                        if (!(m_AIMem[i].m_Row == i_Row && m_AIMem[i].m_Col == i_Col))
                        { // Case the new tile is the other pair
                            m_AIMem[i].m_PairFound = true;
                            m_AIMem[i].m_PairCol = i_Col;
                            m_AIMem[i].m_PairRow = i_Row;
                            m_PairsInMem++;

                            if (m_Revealed % 2 != 0 && m_DoSmartChoice)
                            { // Case found pair in smartcohice (and first reveal was random), replace indexes           
                                m_AIMem[i].m_PairCol = m_AIMem[i].m_Col;
                                m_AIMem[i].m_PairRow = m_AIMem[i].m_Row;
                                m_AIMem[i].m_Col = i_Col;
                                m_AIMem[i].m_Row = i_Row;
                                m_AIMem[i].m_SentFirstLoc = true;
                            }
                        }

                            isFound = true;
                            break;                       
                    }
                }

                if (!isFound) 
                { // Case not seen this tile before, check index not on pair, add new memory cell
                    while (m_AIMem[m_IndexToAdd % k_MaxMem].m_PairFound)
                    {
                        m_IndexToAdd++;
                    }

                    m_AIMem[m_IndexToAdd++ % k_MaxMem] = new AIMemCell(i_Row, i_Col, i_Value);
                }
            }
        }

        private int memoryInRealTime(Board i_Gameboard)
        { 
            //// Called only when AI remember seen pair
            //// Gets active gameboard, and return the index of pair in AI-Memory

            int index = k_NotFound;

            for (int i = 0; i < m_AIMem.Length; i++)
            {
                if (m_Revealed % 2 == 0)
                { // Case second revealed, only look for specific pair
                    if (m_AIMem[i].m_SentFirstLoc)
                    {
                        index = i;
                        break;
                    }
                }
                else
                {
                    if (m_AIMem[i].m_PairFound)
                    { // This memory cell remember pair
                        if (!i_Gameboard.m_Board[m_AIMem[i].m_PairRow, m_AIMem[i].m_PairCol].Expose)
                        { // Case pair isn't expose
                            index = i;
                            break;
                        }
                        else
                        { // Case the pair that the AI remembers was already found by other player, remove from memory
                            m_PairsInMem--;
                            m_AIMem[i].m_PairFound = false;
                            m_AIMem[i].m_SentFirstLoc = false;
                        }
                    }
                }
            }

            return index;
        }

        private void randomChoice(ref int io_Row, ref int io_Col, Board i_Gameboard)
        {
            //// Gets col & row by ref, and gameboard (THAT IS STILL ACTIVE!)
            //// Return's by ref random row & col that haven't been reveled
            
            int loc = 0;
            int maxRnd = i_Gameboard.Cols * i_Gameboard.Rows;

            do
            {
                loc = Game.s_Random.Next(maxRnd);
            }
            while (checkRandomLocation(loc, ref io_Row, ref io_Col, i_Gameboard));
        }

        private bool checkRandomLocation(int i_Num, ref int io_Row, ref int io_Col, Board i_Gameboard)
        {
            io_Row = i_Num / i_Gameboard.Cols;
            io_Col = i_Num % i_Gameboard.Cols;

            return i_Gameboard.m_Board[io_Row, io_Col].Expose;
        }
    }
}