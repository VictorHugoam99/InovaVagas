import React, {useEffect ,useState} from 'react';
import {Link, useHistory} from 'react-router-dom';
import Header from '../../components/header/index';
import Search from '../../components/searchBar/index';
import ButtonFull from '../../components/button/index';
import Footer from '../../components/footer/index';
import facebook from '../../assets/images/facebook_Cinza.png';
import '../../assets/styles/global.css';
import './style.css';
import CardEmpresa from '../../components/cardEmpresa/index';

function EmpresasParceiras(){
    const history = useHistory();

    const [idEmpresa, setIdEmpresa] = useState(0);
    const [empresa, setEmpresa] = useState('');
    const [empresas, setEmpresas] = useState([]);

    useEffect(() => {
        listarEmpresas();
    }, []);

    const listarEmpresas = () => {
        fetch('http://localhost:5000/api/Empresa', {
            method: 'GET',
            headers: {
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
        .then(response => response.json())
        .then(dados => {
            setEmpresas(dados);
            console.log('' + empresas)
        })
        .catch(e => console.error(e));
    }

    return(
        <div className="">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            
            <h2 className="h2">Empresas que contratam aqui:</h2>

            <div className="body">
            <div className="search-container">
                <Search/>
                <ButtonFull tamanho="sm" name="Buscar"/>
            </div>
                <div className="card-container">
                    {
                        empresas.map((item:any) => {
                            return <div className="cardTeste"> <CardEmpresa img={facebook} title={item.nomeFantasia} /></div>
                        })
                    }
                </div>
            </div>
                <Footer/>
        </div>
    )
}

export default EmpresasParceiras;