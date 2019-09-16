using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add more reporting options (per department, all departments etc)

namespace WindowsFormsApp1
{
    class DatabaseManager
    {
        //        public List<List<String>> inventory_database = new List<List<string>>();
        public List<List<String>> SortDatabase(List<List<String>> unsorted_database, string sortby)
        {

            List<String> location_list = new List<String>();
            List<String> type_list = new List<String>();
            List<String> number_list = new List<String>();
            List<String> mac_list = new List<String>();
            List<String> make_list = new List<String>();
            List<String> model_list = new List<String>();
            List<String> version_list = new List<String>();
            List<String> serial_list = new List<String>();
            List<String> os_list = new List<String>();
            List<String> assigned_list = new List<String>();
            List<String> department_list = new List<String>();
            List<String> date_list = new List<String>();
            List<String> comment_list = new List<String>();
            List<String> retired_list = new List<String>();

            List<String> sorted_location_list = new List<String>();
            List<String> sorted_type_list = new List<String>();
            List<String> sorted_number_list = new List<String>();
            List<String> sorted_mac_list = new List<String>();
            List<String> sorted_make_list = new List<String>();
            List<String> sorted_model_list = new List<String>();
            List<String> sorted_version_list = new List<String>();
            List<String> sorted_serial_list = new List<String>();
            List<String> sorted_os_list = new List<String>();
            List<String> sorted_assigned_list = new List<String>();
            List<String> sorted_department_list = new List<String>();
            List<String> sorted_date_list = new List<String>();
            List<String> sorted_comment_list = new List<String>();
            List<String> sorted_retired_list = new List<String>();

            int y = 0;
            while (y < unsorted_database.Count())
            {
                //Console.WriteLine(y);
                location_list.Add(unsorted_database[y][0]);
                type_list.Add(unsorted_database[y][1]);
                number_list.Add(unsorted_database[y][2]);
                mac_list.Add(unsorted_database[y][3]);
                make_list.Add(unsorted_database[y][4]);
                model_list.Add(unsorted_database[y][5]);
                version_list.Add(unsorted_database[y][6]);
                serial_list.Add(unsorted_database[y][7]);
                os_list.Add(unsorted_database[y][8]);
                assigned_list.Add(unsorted_database[y][9]);
                department_list.Add(unsorted_database[y][10]);
                date_list.Add(unsorted_database[y][11]);
                comment_list.Add(unsorted_database[y][12]);
                retired_list.Add(unsorted_database[y][13]);
                y++;
            }

            if (sortby == "location")
            {
                int i = 0;
                int found_at = 0;
                int total_count = location_list.Count();
                List<int> found_list = new List<int>();

                i = 0;
                int checked_records = 0;
                string smallest = "zzzzzzzzzzzzzzzzzzzz";


                while (checked_records < location_list.Count())
                {

                    i = 0;
                    smallest = "zzzzzzzzzzzzzzzzzzzz";
                    while (i < location_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (String.Compare(location_list[i], smallest) <= 0)
                            {
                                smallest = location_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "type")
            {
                int i = 0;
                int found_at = 0;
                int total_count = type_list.Count();
                List<int> found_list = new List<int>();

                i = 0;
                int checked_records = 0;
                string smallest = "zzzzzzzzzzzzzzzzzzzz";


                while (checked_records < type_list.Count())
                {

                    i = 0;
                    smallest = "zzzzzzzzzzzzzzzzzzzz";
                    while (i < type_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (String.Compare(type_list[i], smallest) <= 0)
                            {
                                smallest = type_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "number")
            {
                int i = 0;
                int found_at = 0;
                int total_count = number_list.Count();
                List<int> found_list = new List<int>();

                while (i < total_count)
                {
                    if (int.TryParse(number_list[i], out int testout) == false)
                    {
                        found_at = i;
                        found_list.Add(found_at);

                        sorted_location_list.Add(location_list[found_at]);
                        sorted_type_list.Add(type_list[found_at]);
                        sorted_number_list.Add(number_list[found_at]);
                        sorted_mac_list.Add(mac_list[found_at]);
                        sorted_make_list.Add(make_list[found_at]);
                        sorted_model_list.Add(model_list[found_at]);
                        sorted_version_list.Add(version_list[found_at]);
                        sorted_serial_list.Add(serial_list[found_at]);
                        sorted_os_list.Add(os_list[found_at]);
                        sorted_assigned_list.Add(assigned_list[found_at]);
                        sorted_department_list.Add(department_list[found_at]);
                        sorted_date_list.Add(date_list[found_at]);
                        sorted_comment_list.Add(comment_list[found_at]);
                        sorted_retired_list.Add(retired_list[found_at]);
                    }
                    i++;
                }

                i = 0;
                int checked_records = 0;
                int bad_found = found_list.Count();
                int smallest = 999999;



                while (checked_records < number_list.Count() - bad_found)
                {

                    i = 0;
                    smallest = 999999;
                    while (i < number_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (int.Parse(number_list[i]) <= smallest)
                            {
                                smallest = int.Parse(number_list[i]);
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "mac")
            {
                int i = 0;
                int found_at = 0;
                int total_count = mac_list.Count();
                List<int> found_list = new List<int>();

                i = 0;
                int checked_records = 0;
                string smallest = "zzzzzzzzzzzzzzzzzzzz";


                while (checked_records < mac_list.Count())
                {

                    i = 0;
                    smallest = "zzzzzzzzzzzzzzzzzzzz";
                    while (i < mac_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (String.Compare(mac_list[i], smallest) <= 0)
                            {
                                smallest = mac_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "make")
            {
                int i = 0;
                int found_at = 0;
                int total_count = make_list.Count();
                List<int> found_list = new List<int>();

                i = 0;
                int checked_records = 0;
                string smallest = "zzzzzzzzzzzzzzzzzzzz";


                while (checked_records < make_list.Count())
                {

                    i = 0;
                    smallest = "zzzzzzzzzzzzzzzzzzzz";
                    while (i < make_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (String.Compare(make_list[i], smallest) <= 0)
                            {
                                smallest = make_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "model")
            {
                int i = 0;
                int found_at = 0;
                int total_count = model_list.Count();
                List<int> found_list = new List<int>();

                i = 0;
                int checked_records = 0;
                string smallest = "zzzzzzzzzzzzzzzzzzzz";


                while (checked_records < model_list.Count())
                {

                    i = 0;
                    smallest = "zzzzzzzzzzzzzzzzzzzz";
                    while (i < model_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (String.Compare(model_list[i], smallest) <= 0)
                            {
                                smallest = model_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "version")
            {
                int i = 0;
                int found_at = 0;
                int total_count = version_list.Count();
                List<int> found_list = new List<int>();

                i = 0;
                int checked_records = 0;
                string smallest = "zzzzzzzzzzzzzzzzzzzz";


                while (checked_records < version_list.Count())
                {

                    i = 0;
                    smallest = "zzzzzzzzzzzzzzzzzzzz";
                    while (i < version_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (String.Compare(version_list[i], smallest) <= 0)
                            {
                                smallest = version_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "serial")
            {
                int i = 0;
                int found_at = 0;
                int total_count = serial_list.Count();
                List<int> found_list = new List<int>();

                i = 0;
                int checked_records = 0;
                string smallest = "zzzzzzzzzzzzzzzzzzzz";


                while (checked_records < serial_list.Count())
                {

                    i = 0;
                    smallest = "zzzzzzzzzzzzzzzzzzzz";
                    while (i < serial_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (String.Compare(serial_list[i], smallest) <= 0)
                            {
                                smallest = serial_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "os")
            {
                int i = 0;
                int found_at = 0;
                int total_count = os_list.Count();
                List<int> found_list = new List<int>();

                i = 0;
                int checked_records = 0;
                string smallest = "zzzzzzzzzzzzzzzzzzzz";


                while (checked_records < os_list.Count())
                {

                    i = 0;
                    smallest = "zzzzzzzzzzzzzzzzzzzz";
                    while (i < os_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (String.Compare(os_list[i], smallest) <= 0)
                            {
                                smallest = os_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "assigned")
            {
                int i = 0;
                int found_at = 0;
                int total_count = assigned_list.Count();
                List<int> found_list = new List<int>();

                i = 0;
                int checked_records = 0;
                string smallest = "zzzzzzzzzzzzzzzzzzzz";


                while (checked_records < assigned_list.Count())
                {

                    i = 0;
                    smallest = "zzzzzzzzzzzzzzzzzzzz";
                    while (i < assigned_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (String.Compare(assigned_list[i], smallest) <= 0)
                            {
                                smallest = assigned_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "department")
            {
                int i = 0;
                int found_at = 0;
                int total_count = department_list.Count();
                List<int> found_list = new List<int>();

                i = 0;
                int checked_records = 0;
                string smallest = "zzzzzzzzzzzzzzzzzzzz";


                while (checked_records < department_list.Count())
                {

                    i = 0;
                    smallest = "zzzzzzzzzzzzzzzzzzzz";
                    while (i < department_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (String.Compare(department_list[i], smallest) <= 0)
                            {
                                smallest = department_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            if (sortby == "date")
            {
                int i = 0;
                int found_at = 0;
                int total_count = date_list.Count();
                List<int> found_list = new List<int>();

                while (i < total_count)
                {
                    if (DateTime.TryParse(date_list[i], out DateTime testout) == false)
                    {
                        found_at = i;
                        found_list.Add(found_at);

                        sorted_location_list.Add(location_list[found_at]);
                        sorted_type_list.Add(type_list[found_at]);
                        sorted_number_list.Add(number_list[found_at]);
                        sorted_mac_list.Add(mac_list[found_at]);
                        sorted_make_list.Add(make_list[found_at]);
                        sorted_model_list.Add(model_list[found_at]);
                        sorted_version_list.Add(version_list[found_at]);
                        sorted_serial_list.Add(serial_list[found_at]);
                        sorted_os_list.Add(os_list[found_at]);
                        sorted_assigned_list.Add(assigned_list[found_at]);
                        sorted_department_list.Add(department_list[found_at]);
                        sorted_date_list.Add(date_list[found_at]);
                        sorted_comment_list.Add(comment_list[found_at]);
                        sorted_retired_list.Add(retired_list[found_at]);
                    }
                    i++;
                }

                i = 0;
                int checked_records = 0;
                string smallest = "01/01/2099";
                int bad_found = found_list.Count();


                while (checked_records < date_list.Count() - bad_found)
                {

                    i = 0;
                    smallest = "01/01/2099";
                    while (i < date_list.Count())
                    {

                        if (found_list.Contains(i).Equals(false))
                        {
                            if (DateTime.Parse(date_list[i]) <= DateTime.Parse(smallest))

                            {
                                smallest = date_list[i];
                                found_at = i;
                            }
                        }

                        i++;
                    }

                    found_list.Add(found_at);

                    sorted_location_list.Add(location_list[found_at]);
                    sorted_type_list.Add(type_list[found_at]);
                    sorted_number_list.Add(number_list[found_at]);
                    sorted_mac_list.Add(mac_list[found_at]);
                    sorted_make_list.Add(make_list[found_at]);
                    sorted_model_list.Add(model_list[found_at]);
                    sorted_version_list.Add(version_list[found_at]);
                    sorted_serial_list.Add(serial_list[found_at]);
                    sorted_os_list.Add(os_list[found_at]);
                    sorted_assigned_list.Add(assigned_list[found_at]);
                    sorted_department_list.Add(department_list[found_at]);
                    sorted_date_list.Add(date_list[found_at]);
                    sorted_comment_list.Add(comment_list[found_at]);
                    sorted_retired_list.Add(retired_list[found_at]);

                    checked_records++;
                }
            }

            int addcount = 0;
            List<List<String>> sorted_database = new List<List<String>>();

            while (addcount < sorted_number_list.Count())
            {
                List<String> add_record_list = new List<String>();
                add_record_list.Add(sorted_location_list[addcount]);
                add_record_list.Add(sorted_type_list[addcount]);
                add_record_list.Add(sorted_number_list[addcount]);
                add_record_list.Add(sorted_mac_list[addcount]);
                add_record_list.Add(sorted_make_list[addcount]);
                add_record_list.Add(sorted_model_list[addcount]);
                add_record_list.Add(sorted_version_list[addcount]);
                add_record_list.Add(sorted_serial_list[addcount]);
                add_record_list.Add(sorted_os_list[addcount]);
                add_record_list.Add(sorted_assigned_list[addcount]);
                add_record_list.Add(sorted_department_list[addcount]);
                add_record_list.Add(sorted_date_list[addcount]);
                add_record_list.Add(sorted_comment_list[addcount]);
                add_record_list.Add(sorted_retired_list[addcount]);

                sorted_database.Add(add_record_list);
                addcount++;
            }

            

            return sorted_database;
        }
    }
}

//mac make model version