using System;
using System.Collections.Generic;
using System.Text;
using PhoneAppBackend.Core.DB;
using PhoneAppBackend.Core.Models;
using PhoneAppBackend.Core.Repositories.Framework;

namespace PhoneAppBackend.Core.Repositories
{
   public class MessageInformationRepository : BaseRepository<MessageInformation>, IMessageInformationRepository
    {

        public MessageInformationRepository(ApplicationDbContext database) : base(database)
        {
        }

    }

    public interface IMessageInformationRepository : IBaseRepository<MessageInformation>
    {
    }
}
