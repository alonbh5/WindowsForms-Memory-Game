namespace B20_Ex05
{
    internal class Player           
    {
        private readonly string r_Name;
        private readonly bool r_Pc;
        private int m_Pairs;
        internal AI m_PlayerVsComputer;

        internal Player(string i_Name, bool i_Pc)
        { // Send i_Pc = True if player is AI
            r_Name = i_Name;
            r_Pc = i_Pc;

            if (Pc)
            {
                m_PlayerVsComputer = new AI();
            }
        }

        internal string Name
        {
            get { return r_Name; }
        }

        internal int Pairs
        {
            get { return m_Pairs; }
            set { m_Pairs++; }
        }

        internal bool Pc
        {
            get { return r_Pc; }
        }
    }
}