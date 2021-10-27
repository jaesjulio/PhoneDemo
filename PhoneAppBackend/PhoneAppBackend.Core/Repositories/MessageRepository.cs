using PhoneAppBackend.Core.DB;
using PhoneAppBackend.Core.Models;
using PhoneAppBackend.Core.Repositories.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneAppBackend.Core.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {

        public MessageRepository(ApplicationDbContext database) : base(database)
        {
        }

    }

    public interface IMessageRepository : IBaseRepository<Message>
    {
    }
}
