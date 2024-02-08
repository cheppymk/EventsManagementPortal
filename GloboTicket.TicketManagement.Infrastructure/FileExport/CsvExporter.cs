using CsvHelper;
using CsvHelper.Configuration;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Globalization;
using System.IO;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    // Add any necessary configuration options here
                };
                using var csvWriter = new CsvWriter(streamWriter, csvConfig);
                csvWriter.WriteRecords(eventExportDtos);
                streamWriter.Flush(); // Ensure all data is written to the MemoryStream
            }

            return memoryStream.ToArray();
        }
    }
}
