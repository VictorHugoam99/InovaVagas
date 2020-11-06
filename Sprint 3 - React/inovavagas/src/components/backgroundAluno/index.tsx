import React from 'react';
import './style.css';
// import {Container, Col, Row, Image} from 'react-bootstrap';
import logo from '../../assets/images/nubank.png';

function BackgroundAluno(){
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
        </div>
    )
}
export default BackgroundAluno;

