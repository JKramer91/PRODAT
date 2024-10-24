int *tmp;

void main(int n)
{
    int arr[20];
    squares(n, arr);
    arrsum(n, arr, tmp);

    print *tmp;
}

void squares(int n, int arr[])
{
    int i;
    for (i = 1; i <= n; i = i + 1)
    {
        arr[i - 1] = i * i;
        print arr[i - 1];
    }
}

void arrsum(int n, int arr[], int *tmp)
{
    int sum;
    sum = 0;
    int i;
    for (i = 0; i < n; i = i + 1)
    {
        sum = sum + arr[i];
    }

    *tmp = sum;
}
