namespace BeerApp.BU.DTO;

public  record ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    
}
