public interface IStatus
{
    StatusData Status { get; }

    public void SetStatus(StatusData status);
}