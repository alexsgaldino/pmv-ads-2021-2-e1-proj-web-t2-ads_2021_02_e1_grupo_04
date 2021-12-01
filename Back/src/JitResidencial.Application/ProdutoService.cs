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
        public async Task<ProdutoDto> IncluirProdutos(int userId, ProdutoDto model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);
                
                produto.UserId = userId;
                
                _produtoPersist.Incluir<Produto>(produto);
                if (await _produtoPersist.SalvarAlteracoesAsync())
                {
                    var produtoRetorno = await _produtoPersist.RecuperarProdutoPorIdAsync(userId, produto.Id);
                    return _mapper.Map<ProdutoDto>(produtoRetorno); 
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> ExcluirProduto(int userId, int id)
        {
            try
            {
                var produto = await _produtoPersist.RecuperarProdutoPorIdAsync(userId, id);

                produto.UserId = userId;

                if (produto == null)
                {
                    throw new Exception("Evento para deleção não foi encontrado");
                }

                _produtoPersist.Excluir<Produto>(produto);
                return await _produtoPersist.SalvarAlteracoesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoDto> AlterarProduto(int userId, int id, ProdutoDto model)
        {
            try
            {
                var produto = await _produtoPersist.RecuperarProdutoPorIdAsync(userId, id);
                if (produto == null)
                {
                    return null;
                }
                model.Id = produto.Id;
                model.UserId = userId;

                _mapper.Map(model, produto);

                _produtoPersist.Alterar<Produto>(produto);
                
                if (await _produtoPersist.SalvarAlteracoesAsync())
                {
                    var produtoRetorno =  await _produtoPersist.RecuperarProdutoPorIdAsync(userId, produto.Id);
                    return _mapper.Map<ProdutoDto>(produtoRetorno);
                }
                return null;                

     
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }



        public async Task<ProdutoDto[]> RecuperarProdutosAsync(int userId)
        {
            try
            {
                var produtos = await _produtoPersist.RecuperarProdutosAsync(userId);
                
                 if (produtos == null) return null;

                var produtosRetorno = _mapper.Map<ProdutoDto[]>(produtos);
                
                return produtosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto[]> RecuperarProdutosPorCodigoBarrasAsync(int userId, string codigoBarras)
        {
            try
            {
                var produtos = await _produtoPersist.RecuperarProdutoPorCodigoBarrasAsync(userId, codigoBarras);

                produtos.UserId = userId;

                if (produtos == null) return null;

                var produtosRetorno = _mapper.Map<ProdutoDto[]>(produtos);
                
                return produtosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto[]> RecuperarProdutosPorNomeProdutoAsync(int userId, string nomeProduto)
        {
            try
            {
                var produtos = await _produtoPersist.RecuperarProdutosPorNomeAsync(userId, nomeProduto);


                if (produtos == null) return null;

                var produtosRetorno = _mapper.Map<ProdutoDto[]>(produtos);
                
                return produtosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto> RecuperarProdutoPorIdAsync(int userId, int id)
        {
            try
            {
                var produto = await _produtoPersist.RecuperarProdutoPorIdAsync(userId, id);
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