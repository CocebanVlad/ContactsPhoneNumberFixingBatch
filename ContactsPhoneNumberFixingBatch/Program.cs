using ContactsPhoneNumberFixingBatch;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    HasHeaderRecord = false
};

var reusableStrBuilder = new StringBuilder();

GoogleContactRow header;
List<GoogleContactRow> rows;

using (var reader = new StreamReader(@"C:\Users\Vlad\Downloads\contacts.csv"))
using (var csv = new CsvReader(reader, config))
{
    csv.Read();
    header = csv.GetRecord<GoogleContactRow>();
    rows = csv.GetRecords<GoogleContactRow>().ToList();
}

using (var reader = new StreamWriter(@"C:\Users\Vlad\Downloads\contacts.fixed.csv"))
using (var csv = new CsvWriter(reader, config))
{
    csv.WriteRecord(header);
    csv.NextRecord();

    foreach (var row in rows)
    {
        Update(row);
        csv.WriteRecord(row);
        csv.NextRecord();
    }
}

Console.WriteLine("Done!");
Console.ReadKey();

void Update(GoogleContactRow row)
{
    if (!string.IsNullOrEmpty(row.E_mail1_Value))
        row.E_mail1_Type = "*";

    if (!string.IsNullOrEmpty(row.E_mail2_Value))
        row.E_mail2_Type = "";

    if (row.Notes.StartsWith("This contact is read-only") || row.Notes.StartsWith("#NAME?"))
        row.Notes = "";

    row.Phone1_Type = "";
    row.Phone1_Value = FixPhones(row.Phone1_Value);

    row.Birthday = "";

    row.GroupMembership = "";

    row.Organization1_Type = "";
    row.Organization1_YomiName = "";
    row.Organization1_Department = "";
    row.Organization1_Symbol = "";
    row.Organization1_Location = "";
    row.Organization1_JobDescription = "";
}

string FixPhones(string rawPhonesStr)
{
    if (string.IsNullOrWhiteSpace(rawPhonesStr))
        return "";

    var delimiter = " ::: ";
    var phones = rawPhonesStr.Split(delimiter);

    var result = new List<string>();

    foreach (var rawPhone in phones)
    {
        var phone = RemoveChars(rawPhone, " -()");

        if (!phone.StartsWith('+'))
        {
            if (phone.Length == 11)
            {
                // RO number
                if (phone.StartsWith("40"))
                    phone = "+" + phone;

                // MD number
                if (phone.StartsWith("373"))
                    phone = "+" + phone;
            }
            else if (phone.Length == 10)
            {
                // RO number
                if (phone.StartsWith("07"))
                    phone = "+4" + phone;
            }
            else
            {
                Console.WriteLine($"Dont know what to do with: {phone}");
                continue;
            }
        }

        result.Add(phone);
    }

    return string.Join(delimiter, result);
}

string RemoveChars(string str, string chars)
{
    reusableStrBuilder.Clear();

    foreach (var c in str)
    {
        if (!chars.Contains(c))
            reusableStrBuilder.Append(c);
    }

    return reusableStrBuilder.ToString();
}
