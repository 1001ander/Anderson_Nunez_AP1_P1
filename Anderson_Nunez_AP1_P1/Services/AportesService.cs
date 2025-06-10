using Anderson_Nunez_AP1_P1.DAL;
using Anderson_Nunez_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Anderson_Nunez_AP1_P1;

public class AportesService(IDbContextFactory<Contexto> DbFactory)
{
    // Método para verificar si existe un aporte
    public async Task<bool> Existe(int aporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AnyAsync(a => a.AporteId == aporteId);
    }

    // Método para insertar un nuevo aporte
    private async Task<bool> Insertar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Aportes.Add(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }

    // Método para modificar un aporte existente
    public async Task<bool> Modificar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(aporte);
        var modificado = await contexto.SaveChangesAsync() > 0;
        contexto.Entry(aporte).State = EntityState.Detached;
        return modificado;
    }

    // Método principal para guardar (insertar o modificar)
    public async Task<bool> Guardar(Aportes aporte)
    {
        if (!await Existe(aporte.AporteId))
            return await Insertar(aporte);
        else
            return await Modificar(aporte);
    }

    // Método para eliminar un aporte
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminados = await contexto.Aportes
            .Where(a => a.AporteId == id)
            .ExecuteDeleteAsync();
        return eliminados > 0;
    }

    // Método para buscar un aporte por ID
    public async Task<Aportes?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.AporteId == id);
    }

    // Método para listar aportes según un criterio
    public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>>? criterio = null)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var query = contexto.Aportes.AsNoTracking();

        if (criterio != null)
            query = query.Where(criterio);

        return await query.ToListAsync();
    }


    // Método alternativo para actualizar un aporte
    public async Task<bool> Actualizar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        try
        {
            contexto.Entry(aporte).State = EntityState.Modified;
            var resultado = await contexto.SaveChangesAsync();
            return resultado > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción al actualizar el aporte: {ex.Message}");
            return false;
        }
    }
}