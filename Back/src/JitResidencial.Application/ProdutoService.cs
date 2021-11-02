using System.Diagnostics.Tracing;
using System;
using System.Threading.Tasks;
using JitResidencial.Application.Contratos;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contratos;

namespace JitResidencial.Application
{
    public class ProdutoService : IProdutoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IProdutoPersist _produtoPersist;

        public ProdutoService(IGeralPersist geralPersist, IProdutoPersist produtoPersist)
        {
            _produtoPersist = produtoPersist;
            _geralPersist = geralPersist;
        }
        public async Task<Produto> AddProdutos(Produto model)
        {
            try
            {
                 _geralPersist.Add<Produto>(model);
                 if (await _geralPersist.SaveChangesAsync())
                 {
                     return await _produtoPersist.GetProdutoByIdAsync(model.Id);
                 }
                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteProduto(int produtoId)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produto == null)
                {
                    throw new Exception("Evento para deleção não foi encontrado");
                }

                _geralPersist.Delete<Produto>(produto);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<Produto> UpdateProduto(int produtoId, Produto model)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produto == null)
                {
                    return null;
                }
                model.Id = produto.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _produtoPersist.GetProdutoByIdAsync(model.Id);
                }
                return null;                

     
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }



        public async Task<Produto[]> GetAllProdutosAsync()
        {
            try
            {
                 var produtos = await _produtoPersist.GetAllProdutosAsync();
                 if (produtos == null) return null;

                 return produtos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto[]> GetAllProdutosByCodigoBarrasAsync(string codigoBarras)
        {
            try
            {
                 var produtos = await _produtoPersist.GetAllProdutosByCodigoBarraAsync(codigoBarras);
                 if (produtos == null) return null;

                 return produtos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto[]> GetAllProdutosByNomeProdutoAsync(string nomeProduto)
        {
            try
            {
                 var produtos = await _produtoPersist.GetAllProdutosByNomeProdutoAsync(nomeProduto);
                 if (produtos == null) return null;

                 return produtos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> GetProdutoByIdAsync(int produtoId)
        {
            try
            {
                var produtos = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produtos == null) return null;

                return produtos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }


    }
}