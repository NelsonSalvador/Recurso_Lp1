namespace Program
{
    /// <summary>
    /// An enum defining the health status of the agents
    /// </status>
    public enum Status
    {
        /// <summary>
        /// Alive and not infected. Initial status.
        /// </summary>
        Healthy,
        /// <summary>
        /// Infected.
        /// </summary>
        Infected,
        /// <summary>
        /// Dead.false Occurs after being infected for a certain number of 
        /// turns.
        /// </summary>
        Dead
    }
}