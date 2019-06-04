package br.com.pratoTest.Model;

public class Prato {
	private String nome;
	private String caracteristica;
	
	public Prato() {}
	
	public Prato(String nome, String caracteristica) {
		this.nome = nome;
		this.caracteristica = caracteristica;
	}
	
	public String getNome() {
		return nome;
	}
	public void setNome(String nome) {
		this.nome = nome;
	}
	public String getCaracteristica() {
		return caracteristica;
	}
	public void setCaracteristica(String caracteristica) {
		this.caracteristica = caracteristica;
	}
	
	
}
