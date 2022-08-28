// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter array length");
int length = int.Parse(Console.ReadLine());
Console.WriteLine();
var array = GenerateArray(length);
Output(array);
MergeSort(array, 0, array.Length);
Output(array);

int[] GenerateArray(int length)
{
    var ret = new int[length];
    Random rnd = new Random();

    for (int i = 0; i < length; i++)
        ret[i] = rnd.Next(0, 100);

    return ret;
}

void MergeSort(int[] A, int p, int r)
{
    if (p + 1 < r)
    {
        int q = (p + 1 + r) / 2;
        MergeSort(A, p, q);
        MergeSort(A, q, r);
        Merge(A, p, q, r);
    }
}

void Merge(int[] A, int p, int q, int r)
{
    int n1 = q - p;
    int n2 = r - q;
    int[] L = new int[n1];
    int[] R = new int[n2];
    for (int l = 0; l < n1; l++)
        L[l] = A[p + l];
    for (int l = 0; l < n2; l++)
        R[l] = A[q + l];
    int i = 0, j = 0;
    for (int k = p; k < r; k++)
    {
        if (i >= L.Length)
        {
            A[k] = R[j];
            j++;
        }
        else if (j >= R.Length)
        {
            A[k] = L[i];
            i++;
        }
        else if (L[i] <= R[j])
        {
            A[k] = L[i];
            i++;
        }
        else 
        {
            A[k] = R[j];
            j++;
        }
    }
}

void Output(int[] arr)
{
    foreach (int i in arr)
        Console.WriteLine(i);
    Console.WriteLine();
}