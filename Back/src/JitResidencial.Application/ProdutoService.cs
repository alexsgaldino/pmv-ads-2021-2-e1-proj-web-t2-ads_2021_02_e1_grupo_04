using System.Diagnostics.Tracing;
using System;
using System.Threading.Tasks;
using JitResidencial.Application.Contratos;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contratos;
using JitResidencial.Application.Dtos;
using System.Collections.Generic;
using AutoMapper;

namespace JitResidencial.Application
{
    public class ProdutoService : IProdutoService
    {
        private readonly IGlobalPersist _globalPersist;
        private readonly IProdutoPersist _produtoPersist;

        private readonly IMapper _mapper;

        public ProdutoService(  IProdutoPersist produtoPersist,
                                IMapper mapper)
        {
            _produtoPersist = produtoPersist;
            _mapper = mapper;
   
        }
        public async Task<ProdutoDto> AddProdutos(ProdutoDto model)
        {
            try
            {
                 var produto = _mapper.Map<Produto>(model);
                _produtoPersist.Add<Produto>(produto);
                 if (await _produtoPersist.SaveChangesAsync())
                 {
                     var produtoRetorno = await _produtoPersist.GetProdutoByIdAsync(produto.Id);
                    return _mapper.Map<ProdutoDto>(produtoRetorno); 
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

                _produtoPersist.Delete<Produto>(produto);
                return await _produtoPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoDto> UpdateProduto(int produtoId, ProdutoDto model)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produto == null)
                {
                    return null;
                }
                model.Id = produto.Id;
                
                _mapper.Map(model, produto);

                _produtoPersist.Update<Produto>(produto);
                
                if (await _produtoPersist.SaveChangesAsync())
                {
                    var produtoRetorno =  await _produtoPersist.GetProdutoByIdAsync(produto.Id);
                    return _mapper.Map<ProdutoDto>(produtoRetorno);
                }
                return null;                

     
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }



        public async Task<ProdutoDto[]> GetAllProdutosAsync()
        {
            try
            {
                 var produtos = await _produtoPersist.GetAllProdutosAsync();
                 if (produtos == null) return null;

                var produtosRetorno = _mapper.Map<ProdutoDto[]>(produtos);
                
                return produtosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto[]> GetAllProdutosByCodigoBarrasAsync(string codigoBarras)
        {
            try
            {
                 var produtos = await _produtoPersist.GetAllProdutosByCodigoBarraAsync(codigoBarras);
                 if (produtos == null) return null;

                var produtosRetorno = _mapper.Map<ProdutoDto[]>(produtos);
                
                return produtosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto[]> GetAllProdutosByNomeProdutoAsync(string nomeProduto)
        {
            try
            {
                 var produtos = await _produtoPersist.GetAllProdutosByNomeProdutoAsync(nomeProduto);
                 if (produtos == null) return null;

                var produtosRetorno = _mapper.Map<ProdutoDto[]>(produtos);
                
                return produtosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto> GetProdutoByIdAsync(int produtoId)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produto == null) return null;

                var produtoRetorno = _mapper.Map<ProdutoDto>(produto);
                return produtoRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

    }
}