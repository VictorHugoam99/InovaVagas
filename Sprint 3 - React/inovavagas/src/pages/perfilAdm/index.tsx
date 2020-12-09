import React from 'react';
import Header from '../../components/header';

import logo from '../../assets/images/facebook_Branco.png';
import ButtonFull from '../../components/button';

import './style.css';
import '../../assets/styles/global.css';


function PerfilAdm() {
    return (
        <div><Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <div className="all">
                <div id='caixared'>

                    <div id='logo'>
                        <img src={logo} />
                    </div>

                    <div id='descricao'>
                        <p> Admin 1 </p>
                            <h1>Administrador</h1>
                                <a id='edita' href="#">Editar Perfil</a>
                    </div>
                </div>
                <div className="botoes">
                    <ButtonFull name='Cadastrar Novo Admin' tamanho='lg' />
                </div>

                <p id='titulo'>Dados Cadastrais</p>
                <hr></hr>

                <div className='alinhamentoo'>
                        <h3>Nome: Admin 1</h3>
                        <h3>Titulo do Perfil: Administrador</h3>
                        <h3>Email:</h3>
                        <h3>Endereço:</h3>
                        <h3>Telefone:</h3>
                        <h3>Data de Cadastro:</h3>
                </div>
            </div>
        </div>
    )
}
export default PerfilAdm;