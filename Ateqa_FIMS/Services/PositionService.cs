using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAH_FIMS.Model;
using Microsoft.EntityFrameworkCore;

namespace DAH_FIMS.Services
{
    public class PositionService
    {
        // Instance of the db context
        private readonly DahFIMSDbContext db;

        // Constructor using dependency injection
        public PositionService(DahFIMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Positions
        /// </summary>
        /// <returns>List of all Positions</returns>
        public List<POSITION> GetPositions()
        {
            return db.POSITIONs.ToList();
        }

        /// <summary>
        /// Get a Position
        /// </summary>
        /// <param name="id">Id of the Position to return</param>
        /// <returns>A Position with the provided id or null</returns>
        public POSITION GetPosition(int id)
        {
            return db.POSITIONs.SingleOrDefault(c => c.PositionId == id);
        }

        /// <summary>
        /// Add a new Position
        /// </summary>
        /// <param name="Position">The Position to add</param>
        /// <returns>True if Position is added successfuly otherwise false</returns>
        public bool AddPosition(POSITION position)
        {
            if (position != null)
            {
                db.POSITIONs.Add(position);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a position
        /// </summary>
        /// <param name="id">Id of the position to delete</param>
        /// <returns>True if position is deleted successfuly otherwise false</returns>
        public bool DeletePosition (int id)
        {
            var position = db.POSITIONs.Find(id);
            if (position != null)
            {
                db.POSITIONs.Remove(position);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a position
        /// </summary>
        /// <param name="position">position object</param>
        public void EditPosition(POSITION position)
        {
            // Change the state of the school object to modified, so it will be update in database
            db.Entry(position).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}