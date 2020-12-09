import React from 'react';
import Header from '../../components/header';

import './style.css';
import '../../assets/styles/global.css';

import imgConfig from '../../assets/images/config_Cinza.png';
import Input from '../../components/input';
import Button from 'react-bootstrap/esm/Button';
import ButtonFull from '../../components/button';


function Configuracao() {
    return (
        <div className='config'>
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />

            <div className='content-config'>
                <div className="background">
                    <div className="title">
                        <img src={imgConfig} alt="configuração" />
                        <h1>Configuração</h1>
                    </div>
                    
                    <p>Edite informações da conta!</p>
                
                </div>

                <div className='alinhamento'>
                    <form className='formulario'>

                        <div>
                            <input id='razaoSocial' placeholder='Razão Social' type='text' ></input>

                            <input id='emailcontato' placeholder='Email para contato' type='text' ></input>
                        </div>

                        <div>
                            <input id='nomeFantasia' placeholder='Nome Fantasia' type='text'></input>

                            <input id='ende' placeholder='Endereço' type='text'></input>
                        </div>

                        <div>

                        <input id='atua' placeholder='Atuação' type='text'></input>
                        <input id='tele' placeholder='Telefone' type='text'></input>
                        <input id='celu' placeholder='Celular' type='text'></input>

                        </div>

                        <div>

                            <input id='sede' placeholder='Sede' type='text' />
                            <input id='segui' placeholder='Seguimento' type='text' />
                            <input id='pessoaResponsa' placeholder='Nome da Pessoa Reponsavel pelos Empregos' type='text' />

                        </div>

                        <div>

                            <input id='cnpJ' placeholder='CNPJ' type='text'></input>
                            <input id='cnaE' placeholder='CNAE' type='text' />
                            <input id='emai' placeholder='Email' type='text'></input>

                        </div>

                        <div>

                            <input id='senhaC' placeholder='Senha' type='text'></input>
                            <input id='confS' placeholder='Confirmar Senha' type='text'></input>

                        </div>

                        <div id="botoes">
                            <div id="bSalvar">
                            <ButtonFull name='Salvar' tamanho='lg' />
                            </div>
                        <ButtonFull name='Cancelar'  tamanho='lg' />
                        </div>
                    
                    </form>
                </div>
            </div>
        </div>
    );
}

export default Configuracao;