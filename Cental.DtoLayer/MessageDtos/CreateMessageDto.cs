using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.MessageDtos
{
    public class CreateMessageDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

    }
}
