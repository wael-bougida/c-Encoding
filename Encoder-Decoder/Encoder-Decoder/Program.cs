// See https://aka.ms/new-console-template for more information


string Fichier = "C:/Users/Wael/source/repos/Encoder-Decoder/battery_your.txt";
string output = "C:/Users/Wael/source/repos/Encoder-Decoder/encoded.txt";
string rebuild = "C:/Users/Wael/source/repos/Encoder-Decoder/decoded.txt";

string encodefile(string Filename)
{
    string[] lines = File.ReadAllLines(Filename);

    List<string> counter = new List<string>();
    List<string> charac = new List<string>();
    string resu = "";
    int c = 1;

    foreach (string test in lines)
    {
        for (int i = 0; i < test.Length - 1; i++)
        {
            if (test[i] != test[i + 1])
            {
                //c++;
                //Console.WriteLine("{0}, {1}", test[i], c);
                counter.Add(c.ToString());
                charac.Add(test[i].ToString());
                resu += test[i].ToString() + '.' + c.ToString() + ";";

                c = 1;
            }
            else
            {
                c++;
            }
            if (i == test.Length - 2)
            {
                counter.Add(c.ToString());
                charac.Add(test[i].ToString());
                //Console.WriteLine("{0}, {1}", test[i], c);
                resu += test[i].ToString() + "." + c.ToString() + ";";
            }
        }
        resu += '\n';
        counter.Add("\n");
        charac.Add("\n");
    }
    return resu;
}

string writestringtofile(string str, string filename)
{
    string line = "";
    using (StreamWriter sw = new StreamWriter(filename))
    {
        sw.Write(str);
    }
    return line;
}

string test = encodefile(Fichier);

writestringtofile(test, output);


/*
    Evaluation 
    Reconstruction of Image
 */


string eval = output;


string[] lines = File.ReadAllLines(output);

string[][][] splitarray3times(string[] array)
{
    string[][][] res = new string[array.Length][][];
    for (int i = 0; i < array.Length; i++)
    {
        res[i] = array[i].Split(new char[] { ';' }).Select(x => x.Split('.')).ToArray();
    }
    return res;
}

string[][][] result = splitarray3times(lines);

string printshape(string[][][] array, string filename)
{
    string file = filename;
    string res = "";
    using (StreamWriter sw = new StreamWriter(file))
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                for (int k = 0; k < array[i][j].Length - 1; k++)
                {
                    int n = Int32.Parse(array[i][j][1]);
                    for (int l = 0; l < n; l++)
                    {
                        Console.WriteLine("Accessing... {0}, {1}", i, j, 0);
                        res += (array[i][j][0]);
                        sw.Write(array[i][j][0]);
                    }
;
                }
                //sw.Write("\n");
            }
            sw.Write("\n");
        }
    }
    return res;
}

printshape(result, rebuild);