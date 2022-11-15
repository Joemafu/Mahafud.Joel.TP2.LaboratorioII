using Entidades;
public interface IAccionesRonda
{
    public void Aceptar(Jugador jugador1, Jugador jugador2);
    public void Declinar(Jugador jugador);
    public void TerminarRonda();
}