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
    histogram(n, arr, max, &freq);

    int i;
    i = 0;
    while (i < n)
    {
        print freq[i];
        i = i + 1;
    }
}

void histogram(int n, int ns[], int max, int freq[])
{
    int i;
    i = 0;
    while (i <= max)
    {
        int tmp;
        tmp = 0;
        while (n > 0)
        {
            if (ns[n - 1] == i)
            {
                tmp = tmp + 1;
            }
            n = n - 1;
        }
        freq[i] = tmp;
        i = i + 1;
    }
}