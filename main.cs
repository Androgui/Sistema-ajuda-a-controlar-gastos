def inserir_valores(categorias):
    gastos = []
    for categoria in categorias:
        valor = float(input(f"Insira o valor gasto em {categoria}: "))
        gastos.append(valor)
    return gastos

def total_gastos(gastos):
    return sum(gastos)

def media_gastos(gastos):
    return sum(gastos) / len(gastos)

def maior_gasto(gastos, categorias):
    maior = max(gastos)
    categoria = categorias[gastos.index(maior)]
    return maior, categoria

def menor_gasto(gastos, categorias):
    menor = min(gastos)
    categoria = categorias[gastos.index(menor)]
    return menor, categoria

def exibir_resultados(gastos, categorias):
    total = total_gastos(gastos)
    media = media_gastos(gastos)
    maior, categoria_maior = maior_gasto(gastos, categorias)
    menor, categoria_menor = menor_gasto(gastos, categorias)
    
    print(f"Total de gastos: R$ {total}")
    print(f"Gasto médio mensal: R$ {media}")
    print(f"Maior gasto: R$ {maior} em {categoria_maior}")
    print(f"Menor gasto: R$ {menor} em {categoria_menor}")

def main():
    categorias = ["Alimentação", "Transporte", "Lazer", "Saúde", "Educação"]
    while True:
        gastos = inserir_valores(categorias)
        exibir_resultados(gastos, categorias)
        opcao = input("Deseja inserir novos valores? (s/n): ")
        if opcao.lower() != 's':
            break

if __name__ == "__main__":
    main()
