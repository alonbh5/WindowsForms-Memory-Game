namespace B20_Ex05
{
    internal struct Tile            
    {
        private int m_Value;
        private bool m_Expose;

        internal int Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        internal bool Expose
        {
            get { return m_Expose; }
            set { m_Expose = value; }
        }
    }
}