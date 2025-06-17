using Common;
using DotNetGRPC.Common.Models;
using Grpc.Core;
using Server.Data;


namespace Server.Services;

public class SupplierService : SupplierProto.SupplierProtoBase
{


    private readonly AppDbContext _appDbContext;

    public SupplierService(AppDbContext appDbContext)
    {
        this._appDbContext = appDbContext;
    }


    public override async Task<CreateSupplierResponse> CreateSupplier(CreateSupplierRequest request, ServerCallContext context)
    {

        var entry = this._appDbContext.Suppliers.Add(new SupplierEntity
        {
            Name = request.Name
        });

        await this._appDbContext.SaveChangesAsync();

        return new CreateSupplierResponse
        {
            Message = $"Supplier created with id {entry.Entity.Id}"
        };
    }

    public override Task<GetSupplierByIdResponse> GetSupplierById(GetSupplierByIdRequest request, ServerCallContext context)
    {
        try
        {
            var item = this._appDbContext.Suppliers.First(w => w.Id == request.Id);
            return Task.FromResult(new GetSupplierByIdResponse
            {
                Id = item.Id,
                Name = item.Name
            });
        }
        catch
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Supplier with id {request.Id} not found"));
        }
    }


    public override Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
    {

        var suppliers = this._appDbContext.Suppliers.Select(s => new Supplier
        {
            Id = s.Id,
            Name = s.Name
        });

        var response = new GetAllResponse();
        response.Suppliers.AddRange(suppliers);
        return Task.FromResult(response);
    }


}
