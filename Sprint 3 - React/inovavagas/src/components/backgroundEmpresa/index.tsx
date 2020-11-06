import React from 'react';
import './style.css';
// import {Container, Col, Row, Image} from 'react-bootstrap';
import logo from '../../assets/images/nubank.png';

function BackgroundEmpresa(){
    return(
        
        <div className="all">
            <div className="alinhamento">
                <div className="cab">
                    <div className="box">
                        <h1>Nubank</h1>
                        <div className="h3">
                            <h3>Banco digital</h3>
                        </div>
                    </div>
                    <div className="imagem">
                        <img src={logo}/>
                    </div>
                </div>
            </div>
            <div className="descricao">
                <div className="tamanho">
                    <h1>Empresa</h1>
                    <h3>2000 funcionarios</h3>
                </div>
                <div className="sede">
                    <h1>Sede</h1>
                    <h3>Sao Paulo - SP</h3>
                </div>
                <div className="segmento">
                    <h1>Segmento</h1>
                    <h3>cartão de crédito</h3>
                </div>
            </div>
        </div>
    )
}
export default BackgroundEmpresa;

