describe('Fluxo do freelancer', () => {
    it('Teste 1: Visita página', () => {
      cy.visit('http://localhost:3000/')
    })
  
    it('Teste 2: Cria conta do freelancer', () => {
        cy.get('[data-testid="signup-button"]')
            .click()

        cy.url().should('include', '/register')

        cy.get('[data-testid="email-input"]')
            .type('freelancer@email.com')
            .should('have.value', '')

        cy.get('[data-testid="password-input"]')
            .type('senha')
            .should('have.value', '')

        cy.get('[data-testid="name-input"]')
            .type('Freelancer')
            .should('have.value', '')
  
        cy.get('[data-testid="phone-input"]')
            .type('987654321')
            .should('have.value', '')

        cy.get('[data-testid="freelancer-checkbox"]')
            .click()
        
        cy.get('[data-testid="addskill-button"]')
            .click()

        cy.get('[data-testid="skill-input"]')
            .type('Skill')
            .should('have.value', '')
            .type('{enter}')
  
        cy.get('[data-testid="register-button"]')
            .click()
      })
  
    it('Teste 3: Verifica redirecionamento', () => {
      cy.url().should('include', '/home')
  
      cy.get('[data-testid="findjobs-button"]')
        .click()
    })
  
    it('Teste 4: Verifica se o freelancer está na página contendo a listagem de jobs adequada', () => {
      cy.url().should('include', '/jobs-list/false')
    })
  
    it('Teste 5: Filtra os jobs de acordo com os parâmetros desejados', () => {
      cy.get('[data-testid="perhour-checkbox"]')
        .click()
  
      cy.get('[data-testid="perhourlower-input"]')
        .type('50')
        .should('have.value', '')
  
      cy.get('[data-testid="perhourupper-input"]')
        .type('50')
        .should('have.value', '')
  
      cy.get('[data-testid="deadlinelower-input"]')
        .type('13')
        .should('have.value', '')
  
      cy.get('[data-testid="deadlineupper-input"]')
        .type('13')
        .should('have.value', '')
  
      cy.get('[data-testid="skill-input"]')
        .type('Skill')
        .should('have.value', '')
  
      cy.get('[data-testid="addskill-button"]')
        .click()
  
      cy.get('[data-testid="Job-button"]')
        .first().click()
    })
  
    it('Teste 6: Verifica que as informações do job estão de acordo com os filtros aplicados', () => {
      cy.get('[data-testid="price-div"]')
        .contains('R$ 50/h')
  
      cy.get('[data-testid="skills-div"]')
        .contains('Skill')
    })
  
    it('Teste 7: Candidata-se para o job selecionado', () => {
      cy.get('[data-testid="apply-button"]')
        .click()
    })

    it('Teste 8: Verifica que realmente está candidatado', () => {
        cy.get('[data-testid="gray-button"]')
          .contains('Candidatado')
      })
  
    it('Teste 9: Faz o logout', () => {
      cy.get('[data-testid="menu-button"]')
        .click()
  
      cy.get('[data-testid="logout-button"]')
        .click()
  
      cy.get('[data-testid="login-button"]')
    })
  })