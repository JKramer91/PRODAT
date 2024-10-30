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
    while (n > 0)
    {
        arr[n - 1] = n * n;
        print arr[n - 1];
        n = n - 1;
    }
}

void arrsum(int n, int arr[], int *tmp)
{
    int sum;
    sum = 0;
    while (n > 0)
    {
        sum = sum + arr[n - 1];
        n = n - 1;
    }

    *tmp = sum;
}