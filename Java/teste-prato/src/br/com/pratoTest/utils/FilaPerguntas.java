package br.com.pratoTest.utils;

import java.util.ArrayList;

import br.com.pratoTest.Model.Pergunta;
import br.com.pratoTest.Model.Prato;

public class FilaPerguntas {
	
	private ArrayList<Pergunta> elements; 
	private int count = 0;


	public int getCount() {
		return count;
	}


	public void setCount(int count) {
		this.count = count;
	}


	public FilaPerguntas() {
		elements = new ArrayList<Pergunta>(); 
		
	}


	public boolean push(Pergunta novaPergunta) {
		
         elements.add(elements.size() == 0 ? 0 : elements.size()-1, novaPergunta); 
         return true;
	}


	public Pergunta top() {
		if (elements.size() == 0) return null;
		
		Pergunta pergunta = elements.get(0);
		
		return pergunta;
	}
	
	public Pergunta get(int index) {
		if (elements.size() == 0) return null;
		
		Pergunta pergunta = elements.get(index);
		
		return pergunta;
	}
	
	public Pergunta next() {
		if (elements.size() == 0) return null;
		
		Pergunta pergunta = elements.get(count);
		count++;
		return pergunta;
	}
	
	public Pergunta tail() {
		if (elements.size() == 0) return null;
		
		Pergunta pergunta = elements.get(elements.size()-1);
		return pergunta;
	}

	public int size() {
		return elements.size();
	}

}
