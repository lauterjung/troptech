var aluno: Aluno = new Aluno("A", 30);
console.log(aluno);
aluno.nome = "B";
aluno.idade = 34;
aluno.desativar();
aluno.gerarMatricula;
console.log(aluno);

console.log("--------------");

var professor: Professor = new Professor("A", "A");
console.log(professor);
professor.nome = "B";
professor.disciplina = "B";
professor.desativar();
professor.gerarMatricula;
console.log(professor);

console.log("--------------");

var listaAlunos: Array<Aluno> = [new Aluno("A", 20), new Aluno("B", 30)];
var turma: Turma = new Turma("Turma 1", 2022, professor, listaAlunos);
console.log(turma.alunos);
turma.adicionarAluno(new Aluno("C", 40));
console.log(turma.alunos);
console.log(turma.professor);
console.log(turma.ano);
console.log(turma.sala);
turma.sala = "Turma 2";
console.log(turma.sala);