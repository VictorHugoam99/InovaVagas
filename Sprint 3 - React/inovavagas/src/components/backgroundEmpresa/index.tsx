import React, { useEffect, useState }from 'react';
import './style.css';
import {useHistory} from 'react-router-dom';
import {parseJwt} from '../../services/auth';
// import {Container, Col, Row, Image} from 'react-bootstrap';
import logo from '../../assets/images/facebook_Branco.png';

function BackgroundEmpresa(){
    let history = useHistory();

    const [idEmpresa, setidEmpresa] = useState(0);
    const [nomeFantasia, setNomeFantasia] = useState('');
    const [tamanhoEmpresa, setTamanhoEmpresa] = useState('');
    const [endereco, setEndereco] = useState('');
    const [razaoSocial, setRazaoSocial] = useState('');
    const [ramoAtuacao, setRamoAtuacao] = useState('');

    useEffect(() => {
        listarEmpresaPorId(parseJwt().Id);
    }, [])

    const listarEmpresaPorId = (id:number) => {
        fetch('http://localhost:5000/api/Empresa/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
        .then(resp => resp.json())
        .then(data => {
            setidEmpresa(data.idEmpresa);
            setNomeFantasia(data.nomeFantasia);
            setTamanhoEmpresa(data.tamanhoEmpresa);
            setRazaoSocial(data.razaoSocial);
            setRamoAtuacao(data.ramoAtuacao);
        })
        .catch(e => console.error(e));
    }
    return(
        
        <div className="allEmpresa">
            <div className="alinhamentoEmpresa">
                <div className="cabEmpresa">
                    <div className="boxEmpresa">
                        <h1>{nomeFantasia}</h1>
                        <div className="h3">
                            <h3>{razaoSocial}</h3>
                        </div>
                    </div>
                    <div className="imagemEmpresa">
                        <img className="logoPerfil" src={logo}/>
                    </div>
                </div>
            </div>
            <div className="descricaoEmpresa">
                <div className="tamanhoEmpresa">
                    <h1>Empresa</h1>
                    <h3>{tamanhoEmpresa} funcionarios</h3>
                </div>
                <div className="sedeEmpresa">
                    <h1>Sede</h1>
                    <h3>São Paulo - SP</h3>
                </div>
                <div className="segmentoEmpresa">
                    <h1>Segmento</h1>
                    <h3>{ramoAtuacao}</h3>
                </div>
            </div>
        </div>
    )
}
export default BackgroundEmpresa;

