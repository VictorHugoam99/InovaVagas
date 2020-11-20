import React from 'react';
import Header from '../../components/header/index';
import Footer from '../../components/footer/index';
import BackgroundEmpresa from '../../components/backgroundEmpresa/index';
import '../perfilEmpresa/style.css';

function PerfilEmpresa() {
    return (
        <div className="perfilEmpresa">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <div className="body-perfil">
                <div className="perfil-container">
                    <BackgroundEmpresa />
                </div>
                <div className="text-container">
                    <div className="txt-title">
                        <h2>Sobre a Empresa</h2>
                        <div className="color-line"></div>
                    </div>
                    <p>Somos uma empresa bem legal mesmo você tem que acreditar
                    Somos uma empresa bem legal mesmo você tem que acreditar
                    Somos uma empresa bem legal mesmo você tem que acreditar
                    Somos uma empresa bem legal mesmo você tem que acreditar
                    Somos uma empresa bem legal mesmo você tem que acreditar
                        Somos uma empresa bem legal mesmo você tem que acreditar</p>
                    <div className="txt-title">
                        <h2>Fotos</h2>
                        <div className="color-line"></div>
                    </div>
                </div>
            </div>
            <Footer />
        </div>
    )
}

export default PerfilEmpresa;