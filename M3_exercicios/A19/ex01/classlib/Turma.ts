class Turma {
    private _sala: string;
    private _ano: number;
    private _professor: Professor;
    private _alunos: Array<Aluno>;

    constructor(sala: string, ano: number, professor: Professor, alunos: Array<Aluno>){
        this._sala = sala;
        this._ano = ano;
        this._professor = professor;
        this._alunos = alunos;
    }

    public get sala(): string {
        return this._sala;
    }

    public set sala(sala: string) {
        this._sala = sala;
    }
    
    public get ano(): number {
        return this._ano;
    }

    public set ano(ano: number) {
        this._ano = ano;
    }
    
    public get professor(): Professor {
        return this._professor;
    }

    public set professor(professor: Professor) {
        this._professor = professor;
    }
    
    public get alunos(): Array<Aluno> {
        return this._alunos;
    }

    adicionarAluno = (aluno: Aluno) => { 
        this.alunos.push(aluno);
    }

    removerAluno = () => { 
        this.alunos.pop();
    }
}