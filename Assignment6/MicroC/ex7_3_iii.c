void main(int n)
{
    int arr[7];
    arr[0] = 1;
    arr[1] = 2;
    arr[2] = 1;
    arr[3] = 1;
    arr[4] = 1;
    arr[5] = 2;
    arr[6] = 0;
    int max;
    max = 3;
    int freq[4];
    histogram(n, arr, max, freq);

    int i;
    i = 0;

    for (i = 0; i <= max; i = i + 1)
    {
        print freq[i];
    }
}

void histogram(int n, int ns[], int max, int freq[])
{
    int i;
    i = 0;
    for (i = 0; i <= max; i = i + 1)
    {
        int tmp;
        tmp = 0;
        int j;
        for (j = n; j > 0; j = j - 1)
        {
            if (ns[j] == i)
            {
                tmp = tmp + 1;
            }
        }
        freq[i] = tmp;
    }
}