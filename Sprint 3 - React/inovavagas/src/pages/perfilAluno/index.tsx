import React, {useEffect, useState}from 'react';
import BackgroundAluno from '../../components/backgroundAluno';
import '../perfilAluno/style.css';
import {useHistory} from 'react-router-dom';
import {parseJwt} from '../../services/auth';
import add from '../../assets/images/mais_Cinza.png';
import trash from '../../assets/images/lixo_Cinza.png';
import Header from '../../components/header/index';
import Footer from '../../components/footer/index';

function PerfilAluno(){
    let history = useHistory();
    const [IdAluno, setIdAluno] = useState(0);
    const [Nome, setNome] = useState(0);
    const [Empregado, setEmpregado] = useState('');
    const [IdGenero, setIdGenero] = useState(0);
    // ususario
    const [Telefone,setTelefone ] = useState('');
    const [Celular, setCelular ] = useState('');
    const [EmailContato, setEmailContato ] = useState('');
    // Curriculo
    const [NomeEmpresa, setNomeEmpresa] = useState('');
    const [NomeEscola, setNomeEscola] = useState('');
    const [DataInicioEscola, setDataInicioEscola] = useState('');
    const [DataTerminoEscola, setDataTerminoEscola] = useState('');
    const [Competencia, setCompetencia] = useState('');
    const [LinkLinkedIn, setLinkLinkedIn] = useState('');
    const [LinkGitHub, setLinkGitHub] = useState('');
    const [InformacoesAdicionais, setInformacoesAdicionais] = useState('');

    useEffect(() => {
        listarAlunoPorId(parseJwt().Id);
    }, [])

    const listarAlunoPorId = (id:number) => {
        fetch('http://localhost:5000/api/Aluno/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
        .then(resp => resp.json())
        .then(data => {
            setIdAluno(data.idAluno);
            setNome(data.nome);
            setEmpregado(data.empregado);
            setIdGenero(data.idGenero);
            
            setTelefone(data.telefone); 
            setCelular(data.celular);
            setEmailContato(data.emailContato);
            
            setNomeEmpresa(data.nomeEmpresa);
            setNomeEscola(data.nomeEscola);
            setDataInicioEscola(data.dataInicioEscola);
            setDataTerminoEscola(data.dataTerminoEscola);
            setCompetencia(data.competencia);
            setLinkLinkedIn(data.linkLinkedIn);
            setLinkGitHub(data.linkGitHub);
            setInformacoesAdicionais(data.informacoesAdicionais);
        })
        .catch(e => console.error(e));
    }
    return (
        <div>
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <BackgroundAluno/>

            <div className="box2">
                <div className="sobreusuario">

                    <div className="editar">
                        <a href="../perfilAlunoEditar">Editar Curriculo</a>
                    </div>
                    <h3>{EmailContato}</h3>
                    <h3>{Celular}</h3>
                    <h3>{Telefone}</h3>

                    <div className="p">
                        <p>
                            Experiencia profissional
                        </p>
                    </div>
                    <div className="color-line"></div>
                    <h3>{NomeEmpresa}</h3>
                    <h3>{Empregado}</h3>

                    <div className="p">
                        <p>
                            Formacao academica
                        </p>
                    </div>
                    <div className="color-line"></div>
                    <h4>Ensino medio cursando ou interrompido</h4>
                    <h3>Escola: {NomeEscola}</h3>
                    <h3>{DataInicioEscola} até {DataTerminoEscola}</h3>

                    <div className="p">
                        <p>
                            Competencias
                        </p>
                    </div>
                    <div className="color-line"></div>
                    <h3>{Competencia}</h3>
                    
                    <div className="p">
                        <p>
                            Redes Sociais
                        </p>
                    </div>
                    <div className="color-line"></div>
                    <h3>Linkedin</h3>
                    <h3>{LinkLinkedIn}</h3>
                    <h3>GitHub</h3>
                    <h3>{LinkGitHub}</h3>
                </div>
            </div>
            <Footer/>
        </div>
    )
}

export default PerfilAluno;