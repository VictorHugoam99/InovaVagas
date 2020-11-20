import React from 'react';
import Header from '../../components/header/index';
import Footer from '../../components/footer/index';
import agendaBrancaChecked from '../../assets/images/agendachecked_Branca.png';
import './style.css';

function CadastrosPendentes(){
    return(
        <div className="">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <div className="fundo">
                <div className="tittle">
                    <img src={agendaBrancaChecked} alt="cadastros pendentes" width="40px" height="40px"/>
                    <h2>Cadastros Pendentes</h2>
                </div>
            </div>
            <div className="corpo">
                
            </div>
            <Footer/>
        </div>
    )
}

export default CadastrosPendentes;