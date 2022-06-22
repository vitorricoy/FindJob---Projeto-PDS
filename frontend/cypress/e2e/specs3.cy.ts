describe('Chat', () => {
    it('Teste 1: Visita página', () => {
        cy.visit('http://localhost:3000/')
    })
  
    it('Teste 2: Login no sistema', () => {
        cy.get('[data-testid="email-input"]')
         .type('cliente@email.com')
         .should('have.value', '')

        cy.get('[data-testid="password-input"]')
          .type('senha')
          .should('have.value', '')

        cy.get('[data-testid="login-button"]')
          .click()
    })

    it('Teste 2: Verifica que foi redirecionado para a homepage do cliente', () => {
        cy.url().should('include', '/home')

        cy.get('[data-testid="subtitle-div"]')
            .contains('Cliente')


    })

    it('Teste 3: Acessa os jobs', () => {
        cy.get('[data-testid="myjobs-button"]')
             .click()

        cy.url().should('include', '/jobs-list')
    })

    it('Teste 4: Verifica que o job desejado é exibido corretamente', () => {
        cy.get('[data-testid="search-input"]')
            .type('Job')
            .should('have.value', '')

        cy.get('[data-testid="Job-button"]')
            .first().click()

        cy.url().should('include', '/client-job-view')
    })      

    it('Teste 5: Verifica que existem candidatos disponíveis', () => {
        cy.get('[data-testid="freelancers-div"]')
            .contains('Contratar')
    })

    it('Teste 6: Contrata o freelancer mais recomendado', () => {
        cy.get('[data-testid="hire-button"]')
            .first().click()

        cy.get('[data-testid="about-div"]')
            .contains('Sobre o Freelancer Contratado')
    })

    it('Teste 7: Inicia um chat com o freelancer escolhido', () => {
        cy.get('[data-testid="chat-button"]')
            .click()

        cy.url().should('include', '/chat')

        cy.get('[data-testid="Freelancerconversation-button"]')
            .click()

        cy.get('[data-testid="user-text"]') 
            .contains('Freelancer')
    })

    it('Teste 8: Envia uma mensagem', () => {
        cy.get('[data-testid="message-input"]')
            .type('Mensagem')
            .should('have.value', '')
            .type('{enter}')

        cy.get('[data-testid="message-text"]') 
            .first()
            .contains('Mensagem')


        cy.get('[data-testid="Freelancerconversation-button"]')
            .contains('Você: Mensagem')
    })

    it('Teste 9: Acessa a página do job', () => {
        cy.get('[data-testid="menu-button"]')
            .click()

        cy.get('[data-testid="jobslist-button"]')
            .click()

        cy.get('[data-testid="search-input"]')
            .type('Job')
            .should('have.value', '')

        cy.get('[data-testid="Job-button"]')
            .first().click()
    })

    it('Teste 10: Avalia o freelancer', () => {
        cy.get('[data-testid="ratings-button"]')
            .click()

        cy.get('[data-testid="rate-button"]')
            .click()
    })

    it('Teste 11: Verifica que o job foi concluido', () => {
        cy.get('[data-testid="myjobs-button"]')
             .click()

        cy.get('[data-testid="Job-button"]')
            .should('not.exist');
    })

    it('Teste 13: Faz o logout', () => {
        cy.get('[data-testid="menu-button"]')
            .click()
    
        cy.get('[data-testid="logout-button"]')
            .click()
    
        cy.get('[data-testid="login-button"]')
    })
  })