int Nx, Nr, x, dt, ktp, Q;
double R, dr, dx, a, time;


Nx = 50;
Nr = 15;
double[,] T = new double[Nx, Nr];
double[,] dtemp = new double[Nx, Nr];
R = 0.15;
x = 2;
a = 0.00001;
dt = 1;
dr = R / (Nr - 1);
dx = x / (Nx - 1);
time = 0;

ktp = 23; // коэффициент теплопроводности 
Q = 2000;
// обнуление массивов

Array.Clear(T, Nx, Nr);

Array.Clear(dtemp, Nx, Nr);


while (time < 8000)
{
    time = time + dt;
    time = Math.Round(time, 2);

    for (int i = 0; i < Nx - 1; i++)
    {
        for (int j = 0; j < Nr - 1; j++)
        {
            dtemp[i, j] = dt * a * (((T[i - 1, j] - 2 * T[i, j] + T[i + 1, j]) / Math.Pow(dx, 2)) + 1 / j *
                ((T[i, j] - T[i, j - 1]) / dr) + ((T[i, j - 1] - 2 * T[i, j] + T[i, j + 1]) / Math.Pow(dr, 2)));
        }
    }
    for (int i = 0; i < Nx - 1; i++)
    {
        for (int j = 0; j < Nr - 1; j++)
        {
            T[i, j] = T[i, j] + dtemp[i, j];
        }
    }
    for (int i = 0; i < Nx; i++)
    {
        T[i, Nr - 1] = (Q * dr) / ktp + T[i, Nr - 2];
    }
    if (time > 0)
    {
        Console.WriteLine(time);
        Console.WriteLine(T[25, 4]);
    }
}