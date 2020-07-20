namespace Program
{
    /// <summary>
    /// A enumerate defining direction movement in the game world.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Does not move.
        /// </summary>
        None,
        /// <summary>
        /// Moves up.
        /// </summary>
        N,
        /// <summary>
        /// Moves right.
        /// </summary>
        E,
        /// <summary>
        /// Moves down.
        /// </summary>
        S,
        /// <summary>
        /// Moves left.
        /// </summary>
        W,
        /// <summary>
        /// Moves up and right.
        /// </summary>
        NE,
        /// <summary>
        /// Moves up and left.
        /// </summary>
        NW,
        /// <summary>
        /// Moves down and right.
        /// </summary>
        SE,
        /// <summary>
        /// Moves down and left.
        /// </summary>
        SW,
        /// <summary>
        /// Undefined movement.
        /// </summary>
        Undefined
    }
}