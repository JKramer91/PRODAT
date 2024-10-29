int *tmp;

void main(int n)
{
    testmethod(n);
}

void testmethod(int n)
{
    int i;
    int j;
    int g;
    j = 100;
    g = 0;
    for (i = 1; i <= n; i = i + 1)
    {

        --j;
        ++g;
        print j;
        print g;
    }
}
