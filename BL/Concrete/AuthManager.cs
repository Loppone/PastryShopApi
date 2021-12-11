using AutoMapper;
using PastryShopApi.BL.Abstract;
using PastryShopApi.BL.Models;
using PastryShopApi.DAL.Abstract;

namespace PastryShopApi.BL.Concrete
{
    public class AuthManager : IAuth
    {
        private readonly IMapper _mapper;
        private readonly IRepoAuth _repoAuth;

        public AuthManager(IMapper mapper, IRepoAuth repoAuth)
        {
            _mapper = mapper;
            _repoAuth = repoAuth;
        }

        public Utente Login(string username, string password)
        {
            // Chiamata al Data Abstrction Layer
            var utente = _repoAuth.GetUtente(username, password);

            return _mapper.Map<ModelPastryShop.Utente, PastryShopApi.BL.Models.Utente>(utente);
        }
    }
}
